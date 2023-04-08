#if TAW_DOTWEEN

using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

namespace Plugins.TheAshenWolfLib.Runtime.Scripts._3rdPartyEnhancements
{
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
  }
}
#endif