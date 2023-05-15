using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plugins.TheAshenWolfLib.Runtime.ColorPicker
{
  public class RgbColorPicker : MonoBehaviour
  {
    [SerializeField] private Slider sliderRed;
    [SerializeField] private Slider sliderGreen;
    [SerializeField] private Slider sliderBlue;
    
    [SerializeField, Space] private Image imageRed;
    [SerializeField] private Image imageGreen;
    [SerializeField] private Image imageBlue;

    [SerializeField, Space] private Image color;
    
    [SerializeField, Space] private Button buttonConfirm;
    [SerializeField] private Button buttonCancel;

    private Texture2D textureRed;
    private Texture2D textureGreen;
    private Texture2D textureBlue;
        
    public static RgbColorPicker Instance { get; private set; }

    public IEnumerator Initialize()
    {
      textureRed = new Texture2D(255, 1);
      textureGreen = new Texture2D(255, 1);
      textureBlue = new Texture2D(255, 1);
      
      imageRed.sprite = Sprite.Create(textureRed, new Rect(0, 0, 255, 1), Vector2.zero);
      imageGreen.sprite = Sprite.Create(textureGreen, new Rect(0, 0, 255, 1), Vector2.zero);
      imageBlue.sprite = Sprite.Create(textureBlue, new Rect(0, 0, 255, 1), Vector2.zero);
      
      sliderRed.onValueChanged.AddListener(OnValueChanged);
      sliderGreen.onValueChanged.AddListener(OnValueChanged);
      sliderBlue.onValueChanged.AddListener(OnValueChanged);
        
      OnValueChanged(0);
      Instance = this;
      
      buttonCancel.onClick.AddListener(() => gameObject.SetActive(false));
      gameObject.SetActive(false);

      yield return null;
    }

    public static void Show(Func<Color> onConfirm)
    {
      Instance.buttonConfirm.onClick.RemoveAllListeners();
      Instance.buttonConfirm.onClick.AddListener(() =>
      {
        onConfirm?.Invoke();
        Instance.gameObject.SetActive(false);
      });
      
      Instance.gameObject.SetActive(true);
    }
    
    
    public void OnValueChanged(float value)
    {
      float r = sliderRed.value;
      float g = sliderGreen.value;
      float b = sliderBlue.value;
        
      ApplyGradient(textureRed, new Color(0, g, b), new Color(1, g, b));
      ApplyGradient(textureGreen, new Color(r, 0, b), new Color(r, 1, b));
      ApplyGradient(textureBlue, new Color(r, g, 0), new Color(r, g, 1));
            
      color.color = new Color(r, g, b);
    }
    
    
    
    private void ApplyGradient(Texture2D tex, Color start, Color end)
    {
      for (int i = 0; i < 255; i++)
      {
        tex.SetPixel(i, 0, Color.Lerp(start, end, i / 255f));
      }
        
      tex.Apply();
    }
  }
}