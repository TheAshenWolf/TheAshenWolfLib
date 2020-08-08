using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheAshenWolfLib
{
    public static class RepetitiveStatics
    {
        public static void SetTextButton(Button button, bool isActive, float activeAlpha = 1f, float inactiveAlpha = .33f)
        {
            try
            {
                TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
                button.interactable = isActive;
                Color buttonColor = text.color;
                Color newColor = new Color(buttonColor.r, buttonColor.g, buttonColor.b, isActive ? activeAlpha : inactiveAlpha);
                text.color = newColor;
            }
            catch
            {
                throw new MissingComponentException("Button " + button.name + " does not have a TextMeshPro component.");
            }
            
        }
        
        public static void DestroyAllChildren(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                if (child != transform) GameObject.Destroy(child.gameObject);
            }
        }
        
        public static void DestroyAllChildren(this GameObject gameObject)
        {
            Transform transform = gameObject.transform;
            if (transform == null)
            {
                throw new MissingComponentException("GameObject " + gameObject.name + " does not have a Transform component.");
            }
            foreach (Transform child in transform)
            {
                if (child != transform) GameObject.Destroy(child.gameObject);
            }
        }
        
        // .text for gameobject (TMPro version)
        public static void text(this GameObject gameObject, string text)
        {
            try
            {
                TextMeshProUGUI tmpro;
                tmpro = gameObject.GetComponent<TextMeshProUGUI>();
                tmpro.text = text;
            }
            catch
            {
                throw new MissingComponentException("GameObject " + gameObject.name +
                                              " does not have TextMeshPro component.");
            }
        }
        
        // float map function
        public static float Map(this float value, float inputFrom, float inputTo, float outputFrom, float outputTo)
        {
            if (inputFrom == inputTo || outputFrom == outputTo)
                throw new ArgumentException("Range can not be a single number.");
            return outputFrom + (value - inputFrom) * (outputTo - outputFrom) / (inputTo - inputFrom);
        }

        public static float Map(this float value, (float, float) input, (float, float) output)
        {
            return value.Map(input.Item1, input.Item2, output.Item1, output.Item2);
        }
        
        public static List<int> ListOf(int a, int b)
        {
            if (a > b || a == b) throw new ArgumentException("First element has to be lower than the second one");

            List<int> result = new List<int>();
            for (int i = a; i <= b; i++)
            {
                result.Add(i);
            }

            return result;
        }
    }
}