using System;
using System.Runtime.InteropServices;
using TheAshenWolfLib.Runtime.Scripts.Types;
using UnityEngine;

namespace TheAshenWolfLib.Runtime.Scripts.Utility
{
  /// <summary>
  /// Used to make the game window transparent
  /// </summary>
  public class TransparentWindow : MonoBehaviour
  {
    /// <summary>
    /// Used to get the current window
    /// </summary>
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();
    
    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
    
    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    
    /// <summary>
    /// Margins used by DwmExtendFrameIntoClientArea
    /// </summary>
    public struct MARGINS
    {
      public int cxLeftWidth;
      public int cxRightWidth;
      public int cyTopHeight;
      public int cyBottomHeight;
    }
    
    /// <summary>
    /// Method that allows us to switch margins
    /// </summary>
    /// <returns></returns>
    [DllImport("dwmapi.dll")]
    private static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);
    
    const int GWL_EXSTYLE = -20;
    const uint WS_EX_LAYERED = 0x00080000;
    const uint WS_EX_TRANSPARENT = 0x00000020;
    private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    
    
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
      
      SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);
      SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, 0);
    }
#endif
  }
}