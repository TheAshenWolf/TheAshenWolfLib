using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace TheAshenWolf.Lib.Editor
{
    public class PackageUpdater : EditorWindow
    {
        // Add menu item named "My Window" to the Window menu
        [MenuItem("Tools/TheAshenWolfLib/Update")]
        private static void UpdatePackage()
        {
            string path = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            string text = File.ReadAllText(path);
            DependencyJson obj = JsonConvert.DeserializeObject<DependencyJson>(text);

            if (obj.@lock == null)
            {
                EditorUtility.DisplayDialog("The Ashen Wolf Library", "No locked packages from github are in project.",
                    "Okay");

                return;
            }


            foreach (KeyValuePair<string, LockedPackage> keyValuePair in obj.@lock)
            {
                obj.@lock.Remove(keyValuePair.Key);
                string manifest = JsonConvert.SerializeObject(obj, Formatting.Indented);

                File.WriteAllText(path, manifest);
                AssetDatabase.Refresh();
            }
        }
    }
}