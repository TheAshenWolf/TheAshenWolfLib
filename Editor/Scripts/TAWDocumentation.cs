using UnityEditor;
using UnityEngine;

namespace TheAshenWolf.Editor
{
    public class TAWDocumentation : EditorWindow
    {
        private bool _randomLootPanelOpen = false;
        private bool _repetitiveStaticsPanelOpen = false;
        private bool _treePanelOpen = false;
        private bool _noisePanelOpen = false;
        
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
                _noisePanelOpen = EditorTools.ToggleableTitle("Noise", _noisePanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_noisePanelOpen ? 1 : 0))
                {
                    
                    // Noise2D
                    EditorTools.EditorSubTitle(
                        "<color=blue>public static float</color> PerlinNoise2D(<color=blue>int</color> x, <color=blue>int</color> y, <color=blue>float</color> width, <color=blue>float</color> height, <color=blue>float</color> scale = 1, <color=blue>ulong</color>? seed = <color=blue>null</color>)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>x</b> - X coordinate of the point");
                    GUILayout.Label("    <b>y</b> - Y coordinate of the point");
                    GUILayout.Label("    <b>width</b> - max size along the X axis");
                    GUILayout.Label("    <b>height</b> - max size along the Y axis");
                    GUILayout.Label("    <b>scale</b> - scale of the perlin noise");
                    GUILayout.Label("    <b>seed</b> - Seed used to generate the noise. Leave blank for random.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea(
                        "float[,] generatedPoints = new float[width, height];\n" +
                        "generatedPoints[x,y] = PerlinNoise2D(x, y, width, height, 5) // Seed was not filled in, so it is generated randomly\n"
                                       , textareaStyle);
                    
                    labelStyle.padding = noPadding;
                    
                    
                    // Noise3D
                    EditorTools.EditorSubTitle(
                        "<color=blue>public static float</color> PerlinNoise3D(<color=blue>int</color> x, <color=blue>int</color> y, <color=blue>int</color> z, <color=blue>float</color> width, <color=blue>float</color> height, <color=blue>float</color> depth, <color=blue>float</color> scale = 1, <color=blue>ulong</color>? seed = null)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>x</b> - X coordinate of the point");
                    GUILayout.Label("    <b>y</b> - Y coordinate of the point");
                    GUILayout.Label("    <b>z</b> - Y coordinate of the point");
                    GUILayout.Label("    <b>width</b> - max size along the X axis");
                    GUILayout.Label("    <b>height</b> - max size along the Y axis");
                    GUILayout.Label("    <b>depth</b> - max size along the Z axis");
                    GUILayout.Label("    <b>scale</b> - scale of the perlin noise");
                    GUILayout.Label("    <b>seed</b> - Seed used to generate the noise. Leave blank for random.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea(
                        "float[,,] generatedPoints = new float[width, height, depth];\n" +
                        "generatedPoints[x,y,z] = PerlinNoise2D(x, y, z, width, height, depth, 5) // Seed was not filled in, so it is generated randomly\n"
                        , textareaStyle);
                    
                    labelStyle.padding = noPadding;
                    
                    
                    
                    
                }
                EditorGUILayout.EndFadeGroup();

            GUILayout.EndScrollView();
        }
    }
}