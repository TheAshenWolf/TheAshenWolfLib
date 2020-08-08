using TheAshenWolfLib.Lib.Editor;
using UnityEditor;
using UnityEngine;

namespace TheAshenWolf.Lib.Editor
{
    public class TAWDocumentation : EditorWindow
    {
        private bool _randomLootPanelOpen = false;
        private bool _repetitiveStaticsPanelOpen = false;
        private bool _treePanelOpen = false;
        private bool _editorToolPanelOpen = false;

        private void OnGUI()
        {
            GUIStyle labelStyle = GUI.skin.GetStyle("Label");

            GUILayout.BeginScrollView(maxSize);

            
                // Random Loot
                _randomLootPanelOpen = EditorTools.ToggleableTitle("RandomLoot", _randomLootPanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_randomLootPanelOpen ? 1 : 0))
                {
                    EditorTools.EditorSubTitle("PercentageRoll");
                    EditorTools.EditorSubTitle("WeightedRoll");
                    EditorTools.EditorSubTitle("RandomOfTwo");
                }
                EditorGUILayout.EndFadeGroup();
                
                // Repetitive Statics
                _repetitiveStaticsPanelOpen = EditorTools.ToggleableTitle("RepetitiveStatics", _repetitiveStaticsPanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_repetitiveStaticsPanelOpen ? 1 : 0))
                {
                    EditorTools.EditorSubTitle("SetTextButton");
                    EditorTools.EditorSubTitle("DestroyAllChildren");
                    EditorTools.EditorSubTitle(".text");
                    EditorTools.EditorSubTitle("Map");
                    EditorTools.EditorSubTitle("ListOf");
                }
                EditorGUILayout.EndFadeGroup();
                
                // Tree
                _treePanelOpen = EditorTools.ToggleableTitle("Tree", _treePanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_treePanelOpen ? 1 : 0))
                {
                    EditorTools.EditorSubTitle("Tree (constructor)");
                }
                EditorGUILayout.EndFadeGroup();
                
                // EditorTools
                _editorToolPanelOpen = EditorTools.ToggleableTitle("EditorTools", _editorToolPanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_editorToolPanelOpen ? 1 : 0))
                {
                    EditorTools.EditorSubTitle("EditorTitle");
                    EditorTools.EditorSubTitle("EditorSubTitle");
                    EditorTools.EditorSubTitle("ToggleableTitle");
                    EditorTools.EditorSubTitle("HorizontalLine");
                }
                EditorGUILayout.EndFadeGroup();
                

            GUILayout.EndScrollView();
        }
    }
}