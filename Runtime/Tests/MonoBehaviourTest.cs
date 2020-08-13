using System;
using TheAshenWolf;
using UnityEngine;

namespace Plugins.com.TheAshenWolf.Lib.Runtime.Tests
{
    public class MonoBehaviourTest : MonoBehaviour
    {
        private void Start()
        {
        }

        public void NoiseTest()
        {
            Noise2D noise = new Noise2D(10, 10);
            Debug.Log(noise.Seed);
            foreach (double line in noise.Noise)
            {
                Debug.Log(line);
            }
        }
    }
}