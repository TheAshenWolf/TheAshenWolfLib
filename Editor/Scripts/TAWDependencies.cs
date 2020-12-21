using UnityEditor;
using UnityEngine;

namespace TheAshenWolf.Editor
{
    public class TAWDependencies : EditorWindow
    {
        private void OnGUI()
        {
            GUIStyle labelStyle = GUI.skin.GetStyle("Label");
            
            
            EditorTools.EditorTitle("Required dependencies", 1.25f);
            
            // Zenject
            GUILayout.BeginHorizontal();
            GUILayout.Label("Zenject", GUILayout.Width(200));
            if (GUILayout.Button("Asset Store", GUILayout.Width(180)))
            {
                AssetStoreZenject();   
            }
            GUILayout.EndHorizontal();
           /* 
            // Newtonsoft JSON
            GUILayout.BeginHorizontal();
            GUILayout.Label("Newtonsoft JSON", GUILayout.Width(200));
            if (GUILayout.Button("Asset Store", GUILayout.Width(180)))
            {
                AssetStoreNewtonsoft();   
            }
            GUILayout.EndHorizontal();*/
        }
        
        private static void AssetStoreZenject()
        {
            Application.OpenURL("https://assetstore.unity.com/packages/tools/utilities/extenject-dependency-injection-ioc-157735");
        }
        
        private static void AssetStoreNewtonsoft()
        {
            Application.OpenURL("https://assetstore.unity.com/packages/tools/input-management/json-net-for-unity-11347");
        }
    }
}