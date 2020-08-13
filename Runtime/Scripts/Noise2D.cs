using System;
using System.ComponentModel;

namespace TheAshenWolf
{
    public class Noise2D
    {
        [Description("Generates a Noise (2D field of doubles) and Seed.")]
        public Noise2D(int sizeX, int sizeY, int? seed = null)
        {
            Random r = new Random();
            Seed = seed ?? r.Next(Int32.MaxValue);
            NoiseGenerator generator = new NoiseGenerator(Seed);
            
            this.Noise = new double[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    this.Noise[x, y] = generator.Noise(x, y);
                }
            }
        }
        
        public double[,] Noise { get; private set; }
        public int Seed { get; private set; }
    }
}