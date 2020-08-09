using UnityEditor;
using UnityEngine;

namespace TheAshenWolf.Editor
{
    public class TAWCredits : EditorWindow
    {
        private void OnGUI()
        {
            GUIStyle labelStyle = GUI.skin.GetStyle("Label");
            
            
            EditorTools.EditorTitle("Developed by", 1f);
            
            labelStyle.alignment = TextAnchor.MiddleCenter;
            labelStyle.fontSize = 24;
            labelStyle.fontStyle = FontStyle.Bold;
            GUILayout.Label("TheAshenWolf");

            GUILayout.BeginHorizontal();
                if (GUILayout.Button("GitHub", GUILayout.Width(95)))
                {
                    Application.OpenURL("https://github.com/Pozitrone");
                }

                GUI.enabled = false;
                if (GUILayout.Button("Website", GUILayout.Width(95)))
                {
                    Application.OpenURL("http://theashenwolf.eu/");
                }
                GUI.enabled = true;
                
                if (GUILayout.Button("Google Play", GUILayout.Width(95)))
                {
                    Application.OpenURL("https://play.google.com/store/apps/developer?id=The+Ashen+Wolf");
                }
            GUILayout.EndHorizontal();
            
            
            GUILayout.Space(10);
            if (GUILayout.Button("Donate"))
            {
                Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FJEGEF5HLNBY4&source=url");
            }

            labelStyle.alignment = TextAnchor.MiddleLeft;
            labelStyle.fontSize = 12;
            labelStyle.fontStyle = FontStyle.Normal;
            
        }
    }
}