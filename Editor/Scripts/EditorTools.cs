using System.ComponentModel;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace TheAshenWolf.Editor
{
  public static class EditorTools
  {
    private static string[] ReservedWords =
    {
      "private", "protected", "public", "virtual", "override", "static",
      "bool", "int", "float", "double", "string", "void", "operator", "null", "ulong",
      "List", "Transform", "T"
    };
    
    private static string[] HightlightedWords =
    {
      "this", "constructor"
    };


    public static void EditorTitle(string title, float titleSize = 2)
    {
      GUIStyle labelStyle = GUI.skin.GetStyle("Label");

      labelStyle.alignment = TextAnchor.MiddleCenter;

      int originalFontSize = labelStyle.fontSize;

      labelStyle.fontSize = (int) (labelStyle.fontSize * titleSize);
      labelStyle.fontStyle = FontStyle.Bold;

      GUILayout.Label(title, labelStyle);
      EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

      labelStyle.alignment = TextAnchor.MiddleLeft;
      labelStyle.fontSize = originalFontSize;
      labelStyle.fontStyle = FontStyle.Normal;
    }

    public static void EditorSubTitle(string subtitle, RectOffset padding = null)
    {
      GUIStyle labelStyle = GUI.skin.GetStyle("Label");
      GUIStyle horizontalSliderStyle = GUI.skin.horizontalSlider;

      labelStyle.fontStyle = FontStyle.Bold;
      labelStyle.padding = padding ?? new RectOffset(20, 20, 10, 0);
      horizontalSliderStyle.padding = padding ?? new RectOffset(20, 20, 0, 0);

      GUILayout.Label(subtitle, labelStyle);
      HorizontalLine();
      //EditorGUILayout.LabelField("", horizontalSliderStyle);
      labelStyle.fontStyle = FontStyle.Normal;
      labelStyle.padding = new RectOffset(0, 0, 0, 0);
      horizontalSliderStyle.padding = new RectOffset(0, 0, 0, 0);
    }


    [Description("Creates a panel title with a toggle button.")]
    public static bool ToggleableTitle(string title, bool panelOpen, float titleSize = 2)
    {
      GUIStyle labelStyle = GUI.skin.GetStyle("Label");

      labelStyle.alignment = TextAnchor.MiddleCenter;

      int originalFontSize = labelStyle.fontSize;

      labelStyle.fontSize = (int) (labelStyle.fontSize * titleSize);
      labelStyle.fontStyle = FontStyle.Bold;


      GUILayout.BeginHorizontal();
      GUILayout.Label(title, labelStyle);
      if (GUILayout.Button("Toggle", GUILayout.Width(80)))
      {
        panelOpen = !panelOpen;
      }

      GUILayout.EndHorizontal();
      EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

      labelStyle.alignment = TextAnchor.MiddleLeft;
      labelStyle.fontSize = originalFontSize;
      labelStyle.fontStyle = FontStyle.Normal;

      return panelOpen;
    }

    public static void HorizontalLine(int thickness = 1, int xPadding = 20, int yPadding = 10)

    {
      Rect rect = EditorGUILayout.GetControlRect(false, thickness);

      rect.height = thickness;
      rect.width -= xPadding * 2;
      rect.center = new Vector2(rect.center.x + xPadding, rect.center.y);

      EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
      EditorGUILayout.Space(yPadding);
    }

    public static string ApplyCodeHighlighting(this string source)
    {
      foreach (string word in ReservedWords)
      {
        source = Regex.Replace(source, word + "([^a-zA-Z])", "<color=#8470db>" + word + "</color>$1");
      }
      
      foreach (string word in HightlightedWords)
      {
        source = Regex.Replace(source, word + "([^a-zA-Z])", "<color=purple>" + word + "</color>$1");
      }
      return source;
    }

    public static void CreateParam(string param, string description)
    {
      GUILayout.Label("    <b>" + param + "</b> - " + description);
    }
  }
}