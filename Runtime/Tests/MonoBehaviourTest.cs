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
            Noise.Noise1D n1 = new Noise.Noise1D(10);
            Debug.Log(n1.Seed);
            foreach (double line in n1.Noise)
            {
                Debug.Log(line);
            }
            
            Noise.Noise2D n2 = new Noise.Noise2D(10, 10);
            Debug.Log(n2.Seed);
            foreach (double line in n2.Noise)
            {
                Debug.Log(line);
            }
        }
    }
}