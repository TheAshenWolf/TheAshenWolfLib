using System;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheAshenWolf
{
    public static class RepetitiveStatics
    {
        [Description("Destroys all child GameObjects.")]
        public static void DestroyAllChildren(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                if (child != transform) GameObject.Destroy(child.gameObject);
            }
        }

        [Description(
            "Destroys all child GameObjects. Overload, that takes in a gameObject and gets the transform itself.")]
        public static void DestroyAllChildren(this GameObject gameObject)
        {
            Transform transform = gameObject.transform;
            if (transform == null)
            {
                throw new MissingComponentException("GameObject " + gameObject.name +
                                                    " does not have a Transform component.");
            }

            foreach (Transform child in transform)
            {
                if (child != transform) GameObject.Destroy(child.gameObject);
            }
        }


        // float map function
        public static float Map(this float value, float inputFrom, float inputTo, float outputFrom, float outputTo)
        {
            if (Mathf.Approximately(inputFrom, inputTo) || Mathf.Approximately(outputFrom, outputTo))
                throw new ArgumentException("Range can not be a single number.");
            return outputFrom + (value - inputFrom) * (outputTo - outputFrom) / (inputTo - inputFrom);
        }

        public static float Map(this float value, (float, float) input, (float, float) output)
        {
            return value.Map(input.Item1, input.Item2, output.Item1, output.Item2);
        }

        // List of numbers
        public static List<int> ListOf(int from, int to)
        {
            if (from > to || from == to)
                throw new ArgumentException("First element has to be lower than the second one");

            List<int> result = new List<int>();
            for (int i = from; i <= to; i++)
            {
                result.Add(i);
            }

            return result;
        }

        // Unix time
        public static int GetSecondsFromEpoch()
        {
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (int) (DateTime.UtcNow - epochStart).TotalSeconds;
        }

        public static int GetMillisecondsFromEpoch()
        {
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (int) (DateTime.UtcNow - epochStart).TotalMilliseconds;
        }
    }
}