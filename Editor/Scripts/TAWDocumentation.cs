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
        private bool _monobehavioursPanelOpen = false;
        private bool _saveSystemPanelOpen = false;
        
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
                    EditorTools.EditorSubTitle("<color=#8470db>bool</color> PercentageRoll (<color=#8470db>float</color> percentage)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>percentage</b> - Chance for the function to return true. (in percent)");
                    GUILayout.Space(10);
                    GUILayout.Label("    <b>returns:</b> <color=#8470db>boolean</color> stating if you were lucky or not.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("if (PercentageRoll(10)) \n" +
                                       "{\n" +
                                       "    DropItem(item); // 10% chance to drop the item\n" +
                                       "}", textareaStyle);   
                    
                    
                    // WeightedRoll
                    EditorTools.EditorSubTitle("<color=#8470db>int</color> WeightedRoll (<color=#8470db>List<float></color> weights)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>weights</b> - List of weights to choose from.");
                    GUILayout.Space(10);
                    GUILayout.Label("    <b>returns:</b> <color=#8470db>int</color> marking the index of the chosen weight.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("List<string> items = {\"Leather\", \"Bone\", \"Horn\"};\n" +
                                       "List<float> itemChances = {25, 25, 5};\n\n" +
                                       "DropItem(items[WeightedRoll(itemChances)]);", textareaStyle);
                    
                    
                    // RandomOfTwo
                    EditorTools.EditorSubTitle("<color=#8470db>int</color> RandomOfTwo ()");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>returns:</b> <color=#8470db>int</color> zero or one, 50:50 chance");
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
                    // DestroyAllChildren
                    EditorTools.EditorSubTitle("<color=#8470db>void</color> DestroyAllChildren (<color=purple>this</color> <color=#8470db>Transform</color> transform)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>transform</b> - <color=#8470db>Transform</color> of the element to destroy the children of.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("// Let \"cube\" be a GameObject with several children.\n" +
                                       "Transform cubeTransform = cube.transform;\n" +
                                       "\n" +
                                       "cubeTransform.DestroyAllChildren();", textareaStyle);
                    
                    
                    // Map
                    EditorTools.EditorSubTitle("<color=#8470db>float</color> Map(<color=purple>this</color> <color=#8470db>float</color> value, <color=#8470db>float</color> inputFrom, <color=#8470db>float</color> inputTo, <color=#8470db>float</color> outputFrom, <color=#8470db>float</color> outputTo)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>value</b> - The value to be mapped");
                    GUILayout.Label("    <b>inputFrom</b> - start of the range input is from");
                    GUILayout.Label("    <b>inputTo</b> - end of the range input is from");
                    GUILayout.Label("    <b>outputFrom</b> - start of the range the value should be mapped on");
                    GUILayout.Label("    <b>outputTo</b> - end of the range the value should be mapped on");
                    GUILayout.Space(10);
                    GUILayout.Label("    <b>returns:</b> <color=#8470db>float</color> value which is on the same position to the new range as the old value was to the old range.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("float value = 2648;\n" +
                                       "\n" +
                                       "float percentageValue = value.Map(0f, 10000f, 0f, 100f)", textareaStyle);

                    
                    // ListOf
                    EditorTools.EditorSubTitle("<color=#8470db>List<int></color> ListOf(<color=#8470db>int</color> from, <color=#8470db>int</color> to)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>from</b> - Start of the list");
                    GUILayout.Label("    <b>to</b> - End of the list");
                    GUILayout.Space(10);
                    GUILayout.Label("    <b>returns:</b> <color=#8470db>List<int></color> starting at <i>from</i> ending at <i>to</i> going up by one every place.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("List<int> zeroToHundred = ListOf(0, 100);", textareaStyle);
                    
                    // GetSecondsFromEpoch
                    EditorTools.EditorSubTitle("<color=#8470db>int<int></color> GetSecondsFromEpoch()");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>returns:</b> <color=#8470db>int</color> Amount of seconds since 1. January 1970");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("int secondsSinceEpoch = GetSecondsFromEpoch()", textareaStyle);

                    labelStyle.padding = noPadding;
                    
                    // GetSecondsFromEpoch
                    EditorTools.EditorSubTitle("<color=#8470db>int<int></color> GetMillisecondsFromEpoch()");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>returns:</b> <color=#8470db>int</color> Amount of milliseconds since 1. January 1970");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea("int unixTime = GetMillisecondsFromEpoch()", textareaStyle);

                    labelStyle.padding = noPadding;
                }
                EditorGUILayout.EndFadeGroup();
                
                // Tree
                _treePanelOpen = EditorTools.ToggleableTitle("Tree", _treePanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_treePanelOpen ? 1 : 0))
                {
                    
                    // constructor
                    // todo: example
                    EditorTools.EditorSubTitle("<color=purple>(constructor)</color> <color=#8470db>Tree</color>(<color=#8470db>T</color> data, <color=#8470db>Tree<T></color>[] options)");
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
                        "<color=#8470db>public static float</color> PerlinNoise2D(<color=#8470db>int</color> x, <color=#8470db>int</color> y, <color=#8470db>float</color> width, <color=#8470db>float</color> height, <color=#8470db>float</color> scale = 1, <color=#8470db>ulong</color>? seed = <color=#8470db>null</color>)");
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
                        "<color=#8470db>public static float</color> PerlinNoise3D(<color=#8470db>int</color> x, <color=#8470db>int</color> y, <color=#8470db>int</color> z, <color=#8470db>float</color> width, <color=#8470db>float</color> height, <color=#8470db>float</color> depth, <color=#8470db>float</color> scale = 1, <color=#8470db>ulong</color>? seed = null)");
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
                    
                    // Simplex2D
                    EditorTools.EditorSubTitle(
                        "<color=#8470db>public static double</color> SimplexNoise2D(<color=#8470db>double</color> x, <color=#8470db>double</color> y, <color=#8470db>ulong</color>? seed = <color=#8470db>null</color>)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>x</b> - X coordinate of the point");
                    GUILayout.Label("    <b>y</b> - Y coordinate of the point");
                    GUILayout.Label("    <b>seed</b> - Seed used to generate the noise. Leave blank for random.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea(
                        "double[,] generatedPoints = new double[width, height];\n" +
                        "generatedPoints[x,y] = SimplexNoise2D(x, y) // Seed was not filled in, so it is generated randomly\n"
                        , textareaStyle);
                    
                    labelStyle.padding = noPadding;
                    
                    // Simplex3D
                    EditorTools.EditorSubTitle(
                        "<color=#8470db>public static double</color> SimplexNoise3D(<color=#8470db>double</color> x, <color=#8470db>double</color> y, <color=#8470db>double</color> z, <color=#8470db>ulong</color>? seed = <color=#8470db>null</color>)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>x</b> - X coordinate of the point");
                    GUILayout.Label("    <b>y</b> - Y coordinate of the point");
                    GUILayout.Label("    <b>z</b> - Z coordinate of the point");
                    GUILayout.Label("    <b>seed</b> - Seed used to generate the noise. Leave blank for random.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea(
                        "double[,,] generatedPoints = new double[width, height, depth];\n" +
                        "generatedPoints[x,y,z] = SimplexNoise2D(x, y, z) // Seed was not filled in, so it is generated randomly\n"
                        , textareaStyle);
                    
                    labelStyle.padding = noPadding;
                    
                    
                    // Simplex4D
                    EditorTools.EditorSubTitle(
                        "<color=#8470db>public static double</color> SimplexNoise4D(<color=#8470db>double</color> x, <color=#8470db>double</color> y, <color=#8470db>double</color> z, <color=#8470db>double</color> w, <color=#8470db>ulong</color>? seed = <color=#8470db>null</color>)");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("    <b>x</b> - X coordinate of the point");
                    GUILayout.Label("    <b>y</b> - Y coordinate of the point");
                    GUILayout.Label("    <b>z</b> - Z coordinate of the point");
                    GUILayout.Label("    <b>w</b> - W coordinate of the point");
                    GUILayout.Label("    <b>seed</b> - Seed used to generate the noise. Leave blank for random.");
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea(
                        "double[,,,] generatedPoints = new double[width, height, depth, fourth];\n" +
                        "generatedPoints[x,y,z,w] = SimplexNoise2D(x, y, z, w) // Seed was not filled in, so it is generated randomly\n"
                        , textareaStyle);
                    
                    labelStyle.padding = noPadding;
                }
                EditorGUILayout.EndFadeGroup();
                
                
                
                
                // Monobehaviours
                _monobehavioursPanelOpen = EditorTools.ToggleableTitle("Monobehaviours", _monobehavioursPanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_monobehavioursPanelOpen ? 1 : 0))
                {
                    // Object Rotator
                    EditorTools.EditorSubTitle("<b>Object Rotator</b>");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("Attach to a GameObject and set up within the editor. Used to rotate objects.");
                    GUILayout.Space(20);

                    // Object Pusher
                    EditorTools.EditorSubTitle("<b>Object Pusher</b>");
                    labelStyle.padding = subtitlePadding;
                    GUILayout.Label("Attach to a GameObject and set up within the editor. Used to move objects.");
                    GUILayout.Space(20);
                    
                    labelStyle.padding = noPadding;
                }
                EditorGUILayout.EndFadeGroup();
                
                
                
                
                // SaveSystem
                _saveSystemPanelOpen = EditorTools.ToggleableTitle("Save System", _saveSystemPanelOpen, 1.5f);
                if (EditorGUILayout.BeginFadeGroup(_saveSystemPanelOpen ? 1 : 0))
                {
                    // Simplex4D
                    EditorTools.EditorSubTitle(
                        "public static void SaveBoolean(string name, bool value)".ApplyCodeHighlighting());
                    labelStyle.padding = subtitlePadding;
                    EditorTools.CreateParam("param", "my param");
                    
                    GUILayout.Space(10);
                    GUILayout.Label("<b>Example</b>");
                    GUILayout.TextArea(
                        "example"
                        , textareaStyle);
                    
                    labelStyle.padding = noPadding;
                }
                EditorGUILayout.EndFadeGroup();

            GUILayout.EndScrollView();
        }
    }
}