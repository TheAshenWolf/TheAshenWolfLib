using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheAshenWolfLib.Runtime.Scripts.SpritesAnd2D
{
  public class MultiRendererPanner : MonoBehaviour
  {
    [SerializeField] private List<SpriteRenderer> renderers;
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool moveX = false;
    [SerializeField] private bool moveY = false;
    [SerializeField] private bool alternate = true;
    [SerializeField, Range(0, 1)] private float speedPreservation = 1f;
    private Color _color = Color.white;

    private void Update()
    {
      if (!moveX && !moveY) return;

      float xMovement = (moveX ? 1 : 0) * speed * Time.deltaTime;
      float yMovement = (moveY ? 1 : 0) * speed * Time.deltaTime;

      foreach (SpriteRenderer image in renderers)
      {
        image.transform.localPosition += new Vector3(xMovement, yMovement, 0);
        xMovement *= (alternate ? -1 : 1) * speedPreservation;
        yMovement *= (alternate ? -1 : 1) * speedPreservation;
      }
    }

    public IEnumerator FadeIn()
    {
      float time = 0;
      while (time < 1)
      {
        time += Time.deltaTime;
        SetColor(new Color(_color.r, _color.g, _color.b, time), false);
        yield return null;
      }

      yield return null;
    }
    
    public IEnumerator FadeOut()
    {
      float time = 1;
      while (time > 0)
      {
        time -= Time.deltaTime;
        SetColor(new Color(_color.r, _color.g, _color.b, time), false);
        yield return null;
      }

      yield return null;
    }

    public void SetColor(Color color, bool setDefault = true)
    {
      if (setDefault) _color = color;
      foreach(SpriteRenderer ren in renderers)
      {
        ren.color = color;
      }
    }

    public void Reset()
    {
      foreach (SpriteRenderer ren in renderers)
      {
        ren.transform.localPosition = Vector3.zero;
        ren.color = Color.white;
      }
    }
  }
}