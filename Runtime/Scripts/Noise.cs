using System;
using System.ComponentModel;

namespace TheAshenWolf
{
    public class Noise
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
        
        public class Noise3D
        {
            [Description("Generates a Noise (2D field of doubles) and Seed.")]
            public Noise3D(int sizeX, int sizeY, int sizeZ, int? seed = null)
            {
                Random r = new Random();
                Seed = seed ?? r.Next(Int32.MaxValue);
                NoiseGenerator generator = new NoiseGenerator(Seed);

                this.Noise = new double[sizeX, sizeY, sizeZ];
                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                    {
                        for (int z = 0; z < sizeZ; z++)
                        {
                            this.Noise[x, y, z] = (generator.Noise(x, y) + generator.Noise(z + Seed, x)) / 2;
                        }
                    }
                }
            }

            public double[,,] Noise { get; private set; }
            public int Seed { get; private set; }
        }
        
        public class Noise1D
        {
            [Description("Generates a Noise (array of doubles) and Seed.")]
            public Noise1D(int size, int? seed = null)
            {
                Random r = new Random();
                Seed = seed ?? r.Next(Int32.MaxValue);
                NoiseGenerator generator = new NoiseGenerator(Seed);

                this.Noise = new double[size];
                for (int x = 0; x < size; x++)
                {
                    this.Noise[x] = generator.Noise(x, 0);
                }
            }

            public double[] Noise { get; private set; }
            public int Seed { get; private set; }
        }
        
        public class NoiseGenerator
    {
        public int Seed { get; private set; }

        public int Octaves { get; set; }

        public double Amplitude { get; set; }

        public double Persistence { get; set; }

        public double Frequency { get; set; }

        [Description("Please, use Noise*D instead.")]
        public NoiseGenerator(int seed, int octaves = 8, int amplitude = 1, double frequency = 0.015,
            double persistence = 0.65)
        {
            Seed = seed;
            Octaves = octaves;
            Amplitude = amplitude;
            Frequency = frequency;
            Persistence = persistence;
        }

        public double Noise(int x, int y)
        {
            //returns -1 to 1
            double total = 0.0;
            double freq = Frequency, amp = Amplitude;
            for (int i = 0; i < Octaves; ++i)
            {
                total = total + Smooth(x * freq, y * freq) * amp;
                freq *= 2;
                amp *= Persistence;
            }

            if (total < -2.4) total = -2.4;
            else if (total > 2.4) total = 2.4;

            return (total / 2.4);
        }

        private double NoiseGeneration(int x, int y)
        {
            int n = x + y * 57;
            n = (n << 13) ^ n;

            return (1.0 - ((n * (n * n * 15731 + 789221) + Seed) & 0x7fffffff) / 1073741824.0);
        }

        private double Interpolate(double x, double y, double a)
        {
            double value = (1 - Math.Cos(a * Math.PI)) * 0.5;
            return x * (1 - value) + y * value;
        }

        private double Smooth(double x, double y)
        {
            double n1 = NoiseGeneration((int) x, (int) y);
            double n2 = NoiseGeneration((int) x + 1, (int) y);
            double n3 = NoiseGeneration((int) x, (int) y + 1);
            double n4 = NoiseGeneration((int) x + 1, (int) y + 1);

            double i1 = Interpolate(n1, n2, x - (int) x);
            double i2 = Interpolate(n3, n4, x - (int) x);

            return Interpolate(i1, i2, y - (int) y);
        }
    }
    }
}