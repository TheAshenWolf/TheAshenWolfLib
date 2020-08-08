using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace TheAshenWolfLib
{
    public static class RandomLoot
    {
        [Description("Generates either true or false depending on a percentual chance.")]
        public static bool PercentageRoll(float percentage)
        {
            if (Mathf.Approximately(0f, percentage)) return false;
            if (Mathf.Approximately(100f, percentage)) return true;
            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException("Percentage value has to be between 0 and 100. Your value: " +
                                                      percentage);

            float roll = UnityEngine.Random.Range(0f, 1000f);
            return percentage * 10f > roll;
        }

        [Description("Returns an item index from a weighted roll.")]
        public static int WeightedRoll(List<float> weights)
        {
            float sum = weights.Sum();
            float roll = UnityEngine.Random.Range(0f, sum);

            for (int index = 0; index < weights.Count; index++)
            {
                float weight = weights[index];
                if (roll <= weight)
                {
                    return index;
                }

                roll -= weight;
            }
            
            // According to math, this never happens... but you never know
            throw new Exception("Something went wrong during the WeightedRoll process");
        }

        [Description("Returns either zero or one")]
        public static int RandomOfTwo()
        {
            return UnityEngine.Random.Range(0, 1);
        }
    }

}