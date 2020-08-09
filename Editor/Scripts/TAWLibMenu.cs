using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace TheAshenWolf.Editor
{
    public class TAWLibMenu : EditorWindow
    {
        private static bool _updateOnStartup = false;

        // Add menu item named "My Window" to the Window menu
        private const string _pathManualUpdate = "Tools/TheAshenWolfLib/Update";

        [MenuItem(_pathManualUpdate, false, 0)]
        public static void UpdatePackage()
        {
            string path = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            string text = File.ReadAllText(path);
            DependencyJson obj = JsonConvert.DeserializeObject<DependencyJson>(text);
            
            if (obj.dependencies== null)
            {
                EditorUtility.DisplayDialog("The Ashen Wolf Library", "Manifest is empty.",
                    "Okay");

                return;
            }


            KeyValuePair<string, string> tawlib = new KeyValuePair<string, string>("", "");
            foreach (KeyValuePair<string, string> keyValuePair in obj.dependencies)
            {
                if (keyValuePair.Key == "com.theashenwolf.lib")
                {
                    obj.dependencies.Remove(keyValuePair.Key);
                    string manifest = JsonConvert.SerializeObject(obj, Formatting.Indented);
                                                              
                    File.WriteAllText(path, manifest);
                    AssetDatabase.Refresh();

                    tawlib = new KeyValuePair<string, string>(keyValuePair.Key, keyValuePair.Value);
                    break;
                }
                
            }

            if (tawlib.Key != "")
            {
                obj.dependencies.Add(tawlib.Key, tawlib.Value);
                AssetDatabase.Refresh();
            }
            else
            {
                EditorUtility.DisplayDialog("The Ashen Wolf Library", "Library not found.",
                                    "Okay");
            }
        }


        public const string pathAutoUpdate = "Tools/TheAshenWolfLib/Auto update on startup";

        [MenuItem(pathAutoUpdate, false, 0)]
        private static void UpdateOnStartup()
        {
            // Toggling action
            ToggleStartupUpdate(!TAWLibMenu._updateOnStartup);
        }

        private static void ToggleStartupUpdate(bool enabled)
        {
            // Set checkmark on menu item
            Menu.SetChecked(pathAutoUpdate, enabled);
            // Saving editor state
            EditorPrefs.SetBool(pathAutoUpdate, enabled);

            TAWLibMenu._updateOnStartup = enabled;
        }


        private const string _pathDocumentation = "Tools/TheAshenWolfLib/Show Documentation";
        [MenuItem(_pathDocumentation, false, 100)]
        private static void ShowDocumentation()
        {
            EditorWindow window = GetWindow<TAWDocumentation>();
            Vector2 windowSize = new Vector2(1000f, 800f);
            
            window.position = new Rect(Screen.width / 2f, Screen.height / 2f, windowSize.x, windowSize.y);
            window.maxSize = windowSize;
            window.minSize = windowSize;
            window.titleContent = new GUIContent("TAW Documentation");
            window.Show();
        }

        
        
        private const string _pathDependencies = "Tools/TheAshenWolfLib/Display Dependencies";
        [MenuItem(_pathDependencies, false, 100)]
        private static void ShowDependencies()
        {
            EditorWindow window = GetWindow<TAWDependencies>();
            Vector2 windowSize = new Vector2(400f, 200f);
            
            window.position = new Rect(Screen.width / 2f, Screen.height / 2f, windowSize.x, windowSize.y);
            window.maxSize = windowSize;
            window.minSize = windowSize;
            window.titleContent = new GUIContent("TAW Dependencies");
            window.Show();
        }
        
        
        
        private const string _pathCredits = "Tools/TheAshenWolfLib/Credits";
        [MenuItem(_pathCredits, false, 200)]
        private static void ShowCredits()
        {
            
            
            EditorWindow window = GetWindow<TAWCredits>();
            Vector2 windowSize = new Vector2(300f, 120f);
            
            window.position = new Rect(Screen.width / 2f, Screen.height / 2f, windowSize.x, windowSize.y);
            window.maxSize = windowSize;
            window.minSize = windowSize;
            window.titleContent = new GUIContent("TAW Credits");
            window.Show();
        }
    }

    [InitializeOnLoad]
    public class AutomaticUpdate
    {
        static AutomaticUpdate()
        {
            // Automatic update
            if (EditorPrefs.GetBool(TAWLibMenu.pathAutoUpdate))
            {
                TAWLibMenu.UpdatePackage();
            }
        }
    }
}