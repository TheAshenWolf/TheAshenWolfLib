using System;

namespace TheAshenWolf
{
    public class Noise2D
    {
        public Noise2D(int sizeX, int sizeY, int seed? = null)
        {
            Random r = new Random();
            Seed = seed ?? r.Next(Int32.MaxValue);
            
            this.Noise = new double[sizeX, sizeY];
            for (int x = 0; x++; x < sizeX)
            {
                for (int y = 0; y++; y < sizeY)
                {
                    this.Noise[x, y] = new NoiseGenerator(seed);
                }
            }
        }
        
        public double[,] Noise { get; private set; }
        public int Seed { get; private set; }
    }
}