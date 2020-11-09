using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheAshenWolf.Light
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] private Light light;

        [SerializeField] private int minIntensity;
        [SerializeField] private int maxIntensity;
        [Range(1f, 50f)] [SerializeField] private float smoothing = 25;

        // Update is called once per frame
        private void Update()
        {
            if (!light) return;
            float diff = -light.intensity + Random.Range(minIntensity, maxIntensity);
            light.intensity += diff / smoothing;
        }
    }
}
