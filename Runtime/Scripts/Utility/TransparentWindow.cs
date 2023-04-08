using System;
using UnityEngine;
using static TheAshenWolfLib.Runtime.Scripts.Utility.Dlls;

namespace TheAshenWolfLib.Runtime.Scripts.Utility
{
  /// <summary>
  /// Used to make the game window transparent
  /// </summary>
  public class TransparentWindow : MonoBehaviour
  {
#if !UNITY_EDITOR
    /// <summary>
    /// Gets the active window and makes it transparent
    /// </summary>
    private void Start()
    {
      DontDestroyOnLoad(gameObject);
      IntPtr hWnd = GetActiveWindow();
      MARGINS margins = new MARGINS { cxLeftWidth = -1, cxRightWidth = -1, cyTopHeight = -1, cyBottomHeight = -1 };
      DwmExtendFrameIntoClientArea(hWnd, ref margins);
      
      SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_TRANSPARENT);
    }
#endif
  }
}