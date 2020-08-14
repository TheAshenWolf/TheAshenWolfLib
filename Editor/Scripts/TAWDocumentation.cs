using UnityEditor;
using UnityEngine;

namespace TheAshenWolf.Editor
{
    public class TAWDocumentation : EditorWindow
    {
        private bool _randomLootPanelOpen = false;
        private bool _repetitiveStaticsPanelOpen = false;
        private bool _treePanelOpen = false;
        private bool _noise2dPanelOpen = false;
        
        private Vector2 _scrollPosition;

        private void OnGUI()
        {
            GUIStyle labelStyle = GUI.skin.GetStyle("Label");
            GUIStyle textareaStyle = GUI.skin.textArea;
            textareaStyle.margin = new RectOffset(20,20,0,0);
            textareaStyle.padding = new RectOffset(8,8,8,8);
            
            labelStyle.richText = true;
            RectOffset subtitlePadding = new RectOffset(20,20,0,0);
            RectOffset noPadding = new RectOffset(0,0,0,0);

            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(maxSize.x), GUILayout.Height(maxSize.y));
                
            
                // Random Loot
                _randomLootPanelOpen = EditorTools.ToggleableTitle("RandomLoot", _randomLootPanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_randomLootPanelOpen ? 1 : 0))
                {
                    // PercentageRoll
                    EditorTools.EditorSubTitle("<color=blue>bool</color> PercentageRoll (<color=blue>float</color> percentage)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>percentage</b> - Chance for the function to return true. (in percent)");
                    GUILayout.Space(10);
                    GUILayout.Label("    <b>returns:</b> <color=blue>boolean</color> stating if you were lucky or not.");
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
                    GUILayout.Label("    <b>returns:</b> <color=blue>int</color> marking the index of the chosen weight.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("List<string> items = {\"Leather\", \"Bone\", \"Horn\"};\n" +
                                       "List<float> itemChances = {25, 25, 5};\n\n" +
                                       "DropItem(items[WeightedRoll(itemChances)]);", textareaStyle);
                    
                    
                    // RandomOfTwo
                    EditorTools.EditorSubTitle("<color=blue>int</color> RandomOfTwo ()");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>returns:</b> <color=blue>int</color> zero or one, 50:50 chance");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("List<string> items = {\"Leather\", \"Bone\"};\n\n" +
                                       "DropItem(items[RandomOfTwo()]);", textareaStyle);
                    

                    labelStyle.padding = noPadding;
                }
                EditorGUILayout.EndFadeGroup();
                
                
                
                
                
                // Repetitive Statics
                _repetitiveStaticsPanelOpen = EditorTools.ToggleableTitle("RepetitiveStatics", _repetitiveStaticsPanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_repetitiveStaticsPanelOpen ? 1 : 0))
                {
                    // SetTextButton
                    // todo: example
                    EditorTools.EditorSubTitle("<color=blue>void</color> SetTextButton(<color=blue>Button</color> button, <color=blue>bool</color> isActive, <color=blue>float</color> activeAlpha = 1f, <color=blue>float</color> inactiveAlpha = .33f)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>button</b> - button element to use to create the text button");
                    GUILayout.Label("    <b>isActive</b> - whether the button can be clicked or not");
                    GUILayout.Label("    <b>activeAlpha</b> - alpha channel of the active button, default <i>1f</i>");
                    GUILayout.Label("    <b>inactiveAlpha</b> - alpha channel of the inactive button, default <i>.33f</i>");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("\n Work in progress \n", textareaStyle);
                    
                    
                    // DestroyAllChildren
                    EditorTools.EditorSubTitle("<color=blue>void</color> DestroyAllChildren (<color=purple>this</color> <color=blue>Transform</color> transform)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>transform</b> - <color=blue>Transform</color> of the element to destroy the children of.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("// Let \"cube\" be a GameObject with several children.\n" +
                                       "Transform cubeTransform = cube.transform;\n" +
                                       "\n" +
                                       "cubeTransform.DestroyAllChildren();", textareaStyle);
                    
                    
                    // Map
                    EditorTools.EditorSubTitle("<color=blue>float</color> Map(<color=purple>this</color> <color=blue>float</color> value, <color=blue>float</color> inputFrom, <color=blue>float</color> inputTo, <color=blue>float</color> outputFrom, <color=blue>float</color> outputTo)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>value</b> - The value to be mapped");
                    GUILayout.Label("    <b>inputFrom</b> - start of the range input is from");
                    GUILayout.Label("    <b>inputTo</b> - end of the range input is from");
                    GUILayout.Label("    <b>outputFrom</b> - start of the range the value should be mapped on");
                    GUILayout.Label("    <b>outputTo</b> - end of the range the value should be mapped on");
                    GUILayout.Space(10);
                    GUILayout.Label("    <b>returns:</b> <color=blue>float</color> value which is on the same position to the new range as the old value was to the old range.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("float value = 2648;\n" +
                                       "\n" +
                                       "float percentageValue = value.Map(0f, 10000f, 0f, 100f)", textareaStyle);

                    
                    // ListOf
                    EditorTools.EditorSubTitle("<color=blue>List<int></color> ListOf (<color=blue>int</color> from, <color=blue>int</color> to)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>from</b> - Start of the list");
                    GUILayout.Label("    <b>to</b> - End of the list");
                    GUILayout.Space(10);
                    GUILayout.Label("    <b>returns:</b> <color=blue>List<int></color> starting at <i>from</i> ending at <i>to</i> going up by one every place.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("List<int> zeroToHundred = ListOf(0, 100);", textareaStyle);

                    labelStyle.padding = noPadding;
                }
                EditorGUILayout.EndFadeGroup();
                
                // Tree
                _treePanelOpen = EditorTools.ToggleableTitle("Tree", _treePanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_treePanelOpen ? 1 : 0))
                {
                    
                    // constructor
                    // todo: example
                    EditorTools.EditorSubTitle("<color=purple>(constructor)</color> <color=blue>Tree</color>(<color=blue>T</color> data, <color=blue>Tree<T></color>[] options)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>data</b> - Information stored in particular node");
                    GUILayout.Label("    <b>branches</b> - Another trees.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("\n Work in progress \n", textareaStyle);
                    
                    labelStyle.padding = noPadding;
                }
                EditorGUILayout.EndFadeGroup();
                
                
                // Noise
                _noise2dPanelOpen = EditorTools.ToggleableTitle("Noise", _noise2dPanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_noise2dPanelOpen ? 1 : 0))
                {
                    
                    // Noise1D
                    EditorTools.EditorSubTitle("<color=purple>(constructor)</color> <color=blue>Noise1D</color>(<color=blue>int</color> size, <color=blue>int</color>? seed = <color=blue>null</color>)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>size</b> - Size of the output array");
                    GUILayout.Label("    <b>seed</b> - Seed used to generate the noise. Leave blank for random.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("Noise.Noise1D myNoise = new Noise.Noise1D(10); // Seed was not filled in, so it is generated randomly\n" +
                                       "double[] pattern = myNoise.Noise;\n" +
                                       "int seed = myNoise.Seed;", textareaStyle);
                    
                    labelStyle.padding = noPadding;
                    
                    
                    // Noise2D
                    EditorTools.EditorSubTitle("<color=purple>(constructor)</color> <color=blue>Noise2D</color>(<color=blue>int</color> sizeX, <color=blue>int</color> sizeY, <color=blue>int</color>? seed = <color=blue>null</color>)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>sizeX</b> - Size of the 2D field along X axis");
                    GUILayout.Label("    <b>sizeY</b> - Size of the 2D field along Y axis");
                    GUILayout.Label("    <b>seed</b> - Seed used to generate the noise. Leave blank for random.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("Noise.Noise2D myNoise = new Noise.Noise2D(10, 10); // Seed was not filled in, so it is generated randomly\n" +
                                       "double[,] pattern = myNoise.Noise;\n" +
                                       "int seed = myNoise.Seed;", textareaStyle);
                    
                    labelStyle.padding = noPadding;
                    
                    
                    
                    
                }
                EditorGUILayout.EndFadeGroup();

            GUILayout.EndScrollView();
        }
    }
}