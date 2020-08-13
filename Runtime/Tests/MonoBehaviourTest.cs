using System;
using TheAshenWolf;
using UnityEngine;
using UnityEngine.Events;

namespace Plugins.com.TheAshenWolf.Lib.Runtime.Tests
{
    public class MonoBehaviourTest : MonoBehaviour
    {
        public UnityEvent startupFunction; 
   
        private void Start()
        {
            startupFunction?.Invoke();
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