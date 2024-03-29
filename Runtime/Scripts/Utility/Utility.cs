﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TheAshenWolf
{
  public static class Utility
  {
    [Description("Kills all children inside the jedi temple.")]
    public static void Anakin(this Transform jediTemple)
    {
      foreach (Transform child in jediTemple)
      {
        if (child != jediTemple) GameObject.Destroy(child.gameObject);
      }
    }

    [Description("Kills all children inside the jedi temple. Overload, that takes in a gameObject instead.")]
    public static void Anakin(this GameObject jediTemple)
    {
      Transform transform = jediTemple.transform;
      if (transform == null)
      {
        throw new MissingComponentException("GameObject " + jediTemple.name +
                                            " does not have a Transform component.");
      }

      foreach (Transform child in transform)
      {
        if (child != transform) GameObject.Destroy(child.gameObject);
      }
    }

    [Description("Destroys all child GameObjects except the protected child")]
    public static void DestroyAllChildrenExcept(this Transform transform, Transform protectedChild)
    {
      foreach (Transform child in transform)
      {
        if (child != transform && child != protectedChild) GameObject.Destroy(child.gameObject);
      }
    }


    [Description("Destroys all child GameObjects except the protected children")]
    public static void DestroyAllChildrenExcept(this Transform transform, List<Transform> protectedChildren)
    {
      foreach (Transform child in transform)
      {
        if (child != transform && !protectedChildren.Contains(child)) GameObject.Destroy(child.gameObject);
      }
    }


    // float map function
    public static float Map(this float value, float inputFrom, float inputTo, float outputFrom, float outputTo)
    {
      if (Mathf.Approximately(inputFrom, inputTo) || Mathf.Approximately(outputFrom, outputTo))
        throw new ArgumentException("Range can not be a single number.");
      return outputFrom + (value - inputFrom) * (outputTo - outputFrom) / (inputTo - inputFrom);
    }

    public static double Map(this double value, double inputFrom, double inputTo, double outputFrom, double outputTo)
    {
      if ((Math.Abs(inputFrom - inputTo) < 0.00001) || (Math.Abs(outputFrom - outputTo) < 0.00001))
        throw new ArgumentException("Range can not be a single number.");
      return outputFrom + (value - inputFrom) * (outputTo - outputFrom) / (inputTo - inputFrom);
    }

    public static float Map(this float value, (float, float) input, (float, float) output)
    {
      (float in1, float in2) = input;
      (float out1, float out2) = output;
      return value.Map(in1, in2, out1, out2);
    }

    public static double Map(this double value, (double, double) input, (double, double) output)
    {
      (double in1, double in2) = input;
      (double out1, double out2) = output;
      return value.Map(in1, in2, out1, out2);
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
      return (int)(DateTime.UtcNow - epochStart).TotalSeconds;
    }

    public static int GetMillisecondsFromEpoch()
    {
      DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
      return (int)(DateTime.UtcNow - epochStart).TotalMilliseconds;
    }

    public static Vector2 RandomPointInBounds(this Bounds bounds)
    {
      return new Vector2(
        Random.Range(bounds.min.x, bounds.max.x),
        Random.Range(bounds.min.y, bounds.max.y)
      );
    }

    public static string GetRandomString(int length)
    {
      string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
      string result = "";
      for (int i = 0; i < length; i++)
      {
        result += glyphs[Random.Range(0, glyphs.Length)];
      }

      return result;
    }

    /// <summary>
    /// Returns a random point inside bounds
    /// </summary>
    /// <param name="bounds">Bounds to target</param>
    /// <param name="padding">minX, minY, maxX, maxY</param>
    /// <returns></returns>
    [Description("Returns a random point inside bounds")]
    public static Vector2 Inside(this Bounds bounds, Vector4 padding)
    {
      return new Vector2(
        Random.Range(bounds.min.x + padding.x, bounds.max.x - padding.z),
        Random.Range(bounds.min.y + padding.y, bounds.max.y - padding.w)
      );
    }
    
    /// <summary>
    /// Overload of <see cref="Inside(UnityEngine.Bounds,UnityEngine.Vector4)"/>
    /// </summary>
    public static Vector2 Inside(this Bounds bounds)
    {
      return Inside(bounds, Vector4.zero);
    }
    
    /// <summary>
    /// Gives a random point inside a circle
    /// </summary>
    /// <param name="bounds">Bounds of the circle</param>
    /// <param name="onlyEdge">If set to true, all points will be distributed along the edge</param>
    public static Vector2 InsideCircle(this Bounds bounds, bool onlyEdge = false)
    {
      float angle = 2.0f * (float)Math.PI * Random.Range(0f, 1f);
      float radius = bounds.size.x / 2.0f;
      Vector2 center = bounds.center;
      float rndRadius = onlyEdge ? radius : Random.Range(0f, radius);
      return new Vector2(center.x + rndRadius * Mathf.Cos(angle), center.y + rndRadius * Mathf.Sin(angle));
    }
  }
}