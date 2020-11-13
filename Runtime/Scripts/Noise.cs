using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TheAshenWolf
{
    public static class Noise
    {
        public static float PerlinNoise3D(int x, int y, int z, float width, float height, float depth, float scale = 1, ulong? seed = null)
        {
            if (seed == null) seed = GenerateTimeSeed();

            Double3 offset = GenerateOffsets(seed.Value);
            
            // c stands for calculated
            float cx = (float)(x / width * scale + offset.x);
            float cy = (float)(y / height * scale + offset.y);
            float cz = (float)(z / depth * scale + offset.z);
            
            
            float xy = Mathf.PerlinNoise(cx, cy);
            float xz = Mathf.PerlinNoise(cx, cz);
            float yz = Mathf.PerlinNoise(cy, cz);
            float yx = Mathf.PerlinNoise(cy, cx);
            float zx = Mathf.PerlinNoise(cz, cx);
            float zy = Mathf.PerlinNoise(cz, cy);
 
            return (xy + xz + yz + yx + zx + zy) / 6f;
        }
        
        public static float PerlinNoise2D(int x, int y, float width, float height, float scale = 1, ulong? seed = null)
        {
            if (seed == null) seed = GenerateTimeSeed();

            Double3 offset = GenerateOffsets(seed.Value);
            
            float perlinX = (float)(x / width * scale + offset.x);
            float perlinY = (float)(y / height * scale + offset.y);
        
            float point = Mathf.PerlinNoise(perlinX, perlinY);

            return point;
        }
        
        private static ulong GenerateTimeSeed()
        {
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (ulong) (DateTime.UtcNow - epochStart).TotalMilliseconds;
        }

        private static Double3 GenerateOffsets(ulong seed)
        {
            Random.InitState(Convert.ToInt32(seed));
            Double3 offsets = new Double3
            {
                x = Random.value,
                y = Random.value,
                z = Random.value
            };

            return offsets;
        }

        private struct Double3
        {
            public double x;
            public double y;
            public double z;
        }
    }
}