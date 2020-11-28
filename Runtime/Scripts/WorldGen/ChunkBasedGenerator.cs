using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

// ReSharper disable once CheckNamespace
namespace TheAshenWolf.WorldGen
{
    public class ChunkBasedGenerator : MonoBehaviour
    {
        // Const
        private const int CHUNK_SIZE = 16; // Width and depth of a chunk
        private const int HEIGHT = 64; // Height of the terrain
        
        // Private
        private int _chunkCounterX;
        private int _chunkCounterZ;
        private int _chunkAmountX;
        private int _chunkAmountZ;

        private const int WORLD_SIZE_X = 5;
        private const int WORLD_SIZE_Z = 5;

        private readonly List<Vector3> vertices = new List<Vector3>();
        private readonly List<int> triangles = new List<int>();
        private readonly float[,,] perlinPoints = new float[CHUNK_SIZE + 1, HEIGHT + 1, CHUNK_SIZE + 1];

        // Serialized
        [Title("General Settings")]
        [SerializeField] private Transform chunkHolder;
        [SerializeField] private Material cubeMaterial;
        [SerializeField, Range(0,1), Tooltip("0 = solid ground, 1 = empty space")] private float noiseThreshold = 0.4f;



        // Public
        public List<Chunk> chunks = new List<Chunk>();

        private void Awake()
        {
            GenerateMap();
        }

        private static Vector3 GenerateOffsets(int seed)
        {
            System.Random rnd = new System.Random(seed);
            Vector3 offsets = new Vector3
            {
                x = (float)rnd.NextDouble(),
                y = (float)rnd.NextDouble(),
                z = (float)rnd.NextDouble()
            };

            return offsets;
        }

        private Chunk GenerateChunk(int seed, Vector3 offsets)
        {
            GameObject chunk = new GameObject {name = _chunkCounterX + " " + _chunkCounterZ};
            chunk.transform.parent = chunkHolder;
            chunk.transform.position = new Vector3(_chunkCounterX * CHUNK_SIZE, 0, _chunkCounterZ * CHUNK_SIZE);

            PopulateTerrainMap((ulong) seed);
            CreateMeshData();

            Mesh mesh = BuildMesh("Chunk " + _chunkCounterX + " " + _chunkCounterZ);

            chunk.AddComponent<MeshFilter>().mesh = mesh;
            chunk.AddComponent<MeshRenderer>().material = cubeMaterial;
            chunk.AddComponent<MeshCollider>();

            return new Chunk()
            {
                Map = chunk,
                PositionX = _chunkCounterX,
                PositionZ = _chunkCounterZ,
                Seed = seed,
                Offsets = offsets
            };
        }

        private void GenerateMap(int? seed = null, Vector3? offsets = null)
        {
            _chunkCounterX = 0;
            _chunkCounterZ = 0;


            if (seed == null)
            {
                seed = RepetitiveStatics.GetSecondsFromEpoch();
            }

            if (offsets == null)
            {
                offsets = GenerateOffsets(seed.Value);
            }

            Debug.Log("<b>Seed: </b>" + seed);
            Debug.Log("<b>Offsets: </b>" + offsets);

            _chunkAmountX = WORLD_SIZE_X;
            _chunkAmountZ = WORLD_SIZE_Z;

            for (int i = 0; i < _chunkAmountX; i++)
            {
                for (int j = 0; j < _chunkAmountZ; j++)
                {
                    chunks.Add(GenerateChunk(seed.Value, offsets.Value));
                    _chunkCounterZ++;
                }

                _chunkCounterX++;
                _chunkCounterZ = 0;
            }
        }

        private int GetCubeConfiguration(float[] cube)
        {
            // Starting with a configuration of zero, loop through each point in the cube and check if it is below the terrain surface.
            int configurationIndex = 0;
            for (int i = 0; i < 8; i++)
            {
                // If it is, use bit-magic to the set the corresponding bit to 1. So if only the 3rd point in the cube was below
                // the surface, the bit would look like 00100000, which represents the integer value 32.
                if (cube[i] > noiseThreshold)
                    configurationIndex |= 1 << i;
            }

            return configurationIndex;
        }

        private void MarchCube(Vector3 position, float[] cube)
        {
            // Get the configuration index of this cube.
            int configIndex = GetCubeConfiguration(cube);

            // If the configuration of this cube is 0 or 255 (completely inside the terrain or completely outside of it) we don't need to do anything.
            if (configIndex == 0 || configIndex == 255)
                return;

            // Loop through the triangles. There are never more than 5 triangles to a cube and only three vertices to a triangle.
            int edgeIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int p = 0; p < 3; p++)
                {
                    // Get the current indices. We increment triangleIndex through each loop.
                    int index = TriangulateTable.Table[configIndex, edgeIndex];

                    // If the current edgeIndex is -1, there are no more indices and we can exit the function.
                    if (index == -1)
                        return;

                    // Get the vertices for the start and end of this edge.
                    Vector3 vert1 = position + TriangulateTable.EdgeTable[index, 0];
                    Vector3 vert2 = position + TriangulateTable.EdgeTable[index, 1];

                    // Get the midpoint of this edge.
                    Vector3 vertPosition = (vert1 + vert2) / 2f;

                    // Add to our vertices and triangles list and increment the edgeIndex.
                    vertices.Add(vertPosition);
                    triangles.Add(vertices.Count - 1);
                    edgeIndex++;
                }
            }
        }

        private void CreateMeshData()
        {
            vertices.Clear();
            triangles.Clear();

            // Loop through each "cube" in our terrain.
            for (int x = 0; x < CHUNK_SIZE; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    for (int z = 0; z < CHUNK_SIZE; z++)
                    {
                        // Create an array of floats representing each corner of a cube and get the value from our terrainMap.
                        float[] cube = new float[8];
                        for (int i = 0; i < 8; i++)
                        {
                            Vector3Int corner = new Vector3Int(x, y, z) + TriangulateTable.CornerTable[i];
                            cube[i] = perlinPoints[corner.x, corner.y, corner.z];
                        }

                        // Pass the value into our MarchCube function.
                        MarchCube(new Vector3(x, y, z), cube);
                    }
                }
            }

            // Build Mesh
        }

        private void PopulateTerrainMap(ulong seed)
        {
            // The data points for terrain are stored at the corners of our "cubes", so the terrainMap needs to be 1 larger
            // than the width/height of our mesh.
            for (int x = 0; x < CHUNK_SIZE + 1; x++)
            {
                for (int y = 0; y < HEIGHT + 1; y++)
                {
                    for (int z = 0; z < CHUNK_SIZE + 1; z++)
                    {
                        if (y >= HEIGHT - 1)
                        {
                            perlinPoints[x, y, z] = 0;
                        }
                        else
                        {
                            float point = Noise.PerlinNoise3D(x + _chunkCounterX * CHUNK_SIZE, y,
                                z + _chunkCounterZ * CHUNK_SIZE, CHUNK_SIZE, HEIGHT, CHUNK_SIZE,
                                3,
                                seed);

                            perlinPoints[x, y, z] = point;
                        }
                    }
                }
            }
        }

        private Mesh BuildMesh(string meshName)
        {
            Mesh mesh = new Mesh
            {
                vertices = vertices.ToArray(),
                triangles = triangles.ToArray()
            };
            mesh.RecalculateNormals();
            mesh.name = meshName;
            return mesh;
        }
    }
}