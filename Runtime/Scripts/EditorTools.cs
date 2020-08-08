using UnityEditor;
using UnityEngine;

namespace TheAshenWolfLib
{
    public static class EditorTools
    {
        public static void EditorTitle(string title)
        {
            GUIStyle labelStyle = GUI.skin.GetStyle("Label");
            
            labelStyle.alignment = TextAnchor.MiddleCenter;
            Debug.Log(labelStyle.fontSize);
            labelStyle.fontSize = 2;
            GUILayout.Label(title, labelStyle);
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            labelStyle.alignment = TextAnchor.MiddleLeft;
        }

        public static void EditorSubTitle(string subtitle)
        {
            GUIStyle labelStyle = GUI.skin.GetStyle("Label");
            
            labelStyle.alignment = TextAnchor.MiddleCenter;
            GUILayout.Label(subtitle, labelStyle);
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            labelStyle.alignment = TextAnchor.MiddleLeft;
        }
    }
}