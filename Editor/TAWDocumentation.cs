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
            GUIStyle textareaStyle = GUI.skin.textArea;
            textareaStyle.margin = new RectOffset(20,20,0,0);
            textareaStyle.padding = new RectOffset(8,8,8,8);
            
            labelStyle.richText = true;
            RectOffset subtitlePadding = new RectOffset(20,20,0,0);
            RectOffset noPadding = new RectOffset(0,0,0,0);

            GUILayout.BeginScrollView(maxSize);
                
            
                // Random Loot
                _randomLootPanelOpen = EditorTools.ToggleableTitle("RandomLoot", _randomLootPanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_randomLootPanelOpen ? 1 : 0))
                {
                    // PercentageRoll
                    EditorTools.EditorSubTitle("<color=blue>bool</color> PercentageRoll (<color=blue>float</color> percentage)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>percentage</b> - Chance for the function to return true.");
                    GUILayout.Space(10);
                    GUILayout.Label("    <b>returns</b> - <color=blue>boolean</color> stating if you were lucky or not.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("if (PercentageRoll(10)) \n" +
                                       "{\n" +
                                       "    DropItem(item); // 10% chance to drop the item\n" +
                                       "}", textareaStyle);   
                    
                    
                    // WeightedRoll
                    EditorTools.EditorSubTitle("<color=blue>int</color> WeightedRoll (<color=blue>List<float></color> weights)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>weights</b> - List of weights to choose from.");
                    GUILayout.Space(10);
                    GUILayout.Label("    <b>returns</b> - <color=blue>int</color> marking the index of the chosen weight.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("List<string> items = {\"Leather\", \"Bone\", \"Horn\"};\n" +
                                       "List<float> itemChances = {25, 25, 5};\n" +
                                       "DropItem(items[WeightedRoll(itemChances)]);", textareaStyle);
                    
                    EditorTools.EditorSubTitle("RandomOfTwo");

                    labelStyle.padding = noPadding;
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