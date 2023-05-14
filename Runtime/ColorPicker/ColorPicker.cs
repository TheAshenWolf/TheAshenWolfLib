using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Plugins.TheAshenWolfLib.Runtime.ColorPicker
{
  public class ColorPicker : MonoBehaviour
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
        
    public static ColorPicker Instance { get; private set; }

    private void Start()
    {
      sliderRed.onValueChanged.AddListener(OnValueChanged);
      sliderGreen.onValueChanged.AddListener(OnValueChanged);
      sliderBlue.onValueChanged.AddListener(OnValueChanged);
        
      OnValueChanged(0);
      Instance = this;
      
      buttonCancel.onClick.AddListener(() => gameObject.SetActive(false));
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
        
      ApplyGradient(imageRed, new Color(0, g, b), new Color(1, g, b));
      ApplyGradient(imageGreen, new Color(r, 0, b), new Color(r, 1, b));
      ApplyGradient(imageBlue, new Color(r, g, 0), new Color(r, g, 1));
            
      color.color = new Color(r, g, b);
    }
    
    
    
    private void ApplyGradient(Image image, Color start, Color end)
    {
      Texture2D texture = new Texture2D(255, 1);
        
      for (int i = 0; i < 255; i++)
      {
        texture.SetPixel(i, 0, Color.Lerp(start, end, i / 255f));
      }
        
      texture.Apply();
        
      image.sprite = Sprite.Create(texture, new Rect(0, 0, 255, 1), Vector2.zero);
    }
  }
}