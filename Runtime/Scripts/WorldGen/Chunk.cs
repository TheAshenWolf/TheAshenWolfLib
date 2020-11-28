using UnityEngine;

namespace TheAshenWolf.WorldGen
{
    public class Chunk
    {
        public GameObject Map { get; set; }
        public int PositionX { get; set; }
        public int PositionZ { get; set; }
        public Vector3 Offsets { get; set; }
        public int Seed { get; set; }
    }
}