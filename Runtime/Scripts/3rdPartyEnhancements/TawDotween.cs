#if TAW_DOTWEEN

using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

namespace Plugins.TheAshenWolfLib.Runtime.Scripts._3rdPartyEnhancements
{
  /// <summary>
  /// Extension methods for DOTween
  /// </summary>
  public static class TawDotween
  {
    /// <summary>
    /// Tween the text color of a TextMeshProUGUI
    /// </summary>
    public static TweenerCore<Color, Color, ColorOptions> DOColor(this TextMeshProUGUI target, Color endValue,
      float duration)
    {
      TweenerCore<Color, Color, ColorOptions> t = DOTween.To(() => target.color, x => target.color = x, endValue,
        duration);
      t.SetTarget(target);
      return t;
    }

    /// <summary>
    /// Tween the ortographic size of a camera
    /// </summary>
    /// <returns></returns>
    public static TweenerCore<float, float, FloatOptions> DOOrthoSize(this Camera target, float endValue,
      float duration)
    {
      TweenerCore<float, float, FloatOptions> t = DOTween.To(() => target.orthographicSize,
        x => target.orthographicSize = x, endValue, duration);
      return t;
    }

    /// <summary>
    /// Flashes the text color of a TextMeshProUGUI into a different color and returns it to the original color
    /// </summary>
    /// <param name="target">Targeted TextMeshPro</param>
    /// <param name="endValue">Color to flash into</param>
    /// <param name="duration">Speed of the flash</param>
    /// <param name="repeat">How many times to repeat the flashing</param>
    public static TweenerCore<Color, Color, ColorOptions> DOFlash(this TextMeshProUGUI target, Color endValue,
      float duration, int repeat = 1)
    {
      TweenerCore<Color, Color, ColorOptions> tween = target.DOColor(endValue, duration / 2f).SetLoops(repeat * 2, LoopType.Yoyo);
      return tween;
    }
  }
}
#endif