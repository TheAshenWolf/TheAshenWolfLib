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

    private Vector2 _scrollPosition;

    private void OnGUI()
    {
      GUIStyle labelStyle = GUI.skin.GetStyle("Label");
      GUIStyle textareaStyle = GUI.skin.textArea;
      textareaStyle.margin = new RectOffset(20, 20, 0, 0);
      textareaStyle.padding = new RectOffset(8, 8, 8, 8);

      labelStyle.richText = true;
      RectOffset subtitlePadding = new RectOffset(20, 20, 0, 0);
      RectOffset noPadding = new RectOffset(0, 0, 0, 0);

      _scrollPosition =
        GUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(maxSize.x), GUILayout.Height(maxSize.y));


      // Random Loot
      _randomLootPanelOpen = EditorTools.ToggleableTitle("RandomLoot", _randomLootPanelOpen, 1.5f);
      if (EditorGUILayout.BeginFadeGroup(_randomLootPanelOpen ? 1 : 0))
      {
        // PercentageRoll
        EditorTools.EditorSubTitle("bool PercentageRoll (float percentage)".ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("percentage", "Chance for the function to return true. (in percent)");
        GUILayout.Space(10);
        GUILayout.Label("    <b>returns:</b> boolean stating if you were lucky or not.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea("if (PercentageRoll(10)) \n" +
                           "{\n" +
                           "    DropItem(item); // 10% chance to drop the item\n" +
                           "}", textareaStyle);


        // WeightedRoll
        EditorTools.EditorSubTitle("int WeightedRoll (List<float> weights)".ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("weights", "List of weights to choose from.");
        GUILayout.Space(10);
        GUILayout.Label("    <b>returns:</b> int marking the index of the chosen weight.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea("List<string> items = {\"Leather\", \"Bone\", \"Horn\"};\n" +
                           "List<float> itemChances = {25, 25, 5};\n\n" +
                           "DropItem(items[WeightedRoll(itemChances)]);", textareaStyle);


        // RandomOfTwo
        EditorTools.EditorSubTitle("int RandomOfTwo ()".ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        GUILayout.Label("    <b>returns:</b> int zero or one, 50:50 chance");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea("List<string> items = {\"Leather\", \"Bone\"};\n\n" +
                           "DropItem(items[RandomOfTwo()]);", textareaStyle);


        labelStyle.padding = noPadding;
        GUILayout.Space(25);
      }

      EditorGUILayout.EndFadeGroup();


      // Repetitive Statics
      _repetitiveStaticsPanelOpen = EditorTools.ToggleableTitle("RepetitiveStatics", _repetitiveStaticsPanelOpen, 1.5f);
      if (EditorGUILayout.BeginFadeGroup(_repetitiveStaticsPanelOpen ? 1 : 0))
      {
        // DestroyAllChildren
        EditorTools.EditorSubTitle("void DestroyAllChildren (this Transform transform)".ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("transform", "Transform of the element to destroy the children of.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea("// Let \"cube\" be a GameObject with several children.\n" +
                           "Transform cubeTransform = cube.transform;\n" +
                           "\n" +
                           "cubeTransform.DestroyAllChildren();", textareaStyle);


        // Map
        EditorTools.EditorSubTitle(
          "float Map(this float value, float inputFrom, float inputTo, float outputFrom, float outputTo)"
            .ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("value", "The value to be mapped");
        EditorTools.CreateParam("inputFrom", "start of the range input is from");
        EditorTools.CreateParam("inputTo", "end of the range input is from");
        EditorTools.CreateParam("outputFrom", "start of the range the value should be mapped on");
        EditorTools.CreateParam("outputTo", "end of the range the value should be mapped on");
        GUILayout.Space(10);
        GUILayout.Label(
          "    <b>returns:</b> float value which is on the same position to the new range as the old value was to the old range.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea("float value = 2648;\n" +
                           "\n" +
                           "float percentageValue = value.Map(0f, 10000f, 0f, 100f)", textareaStyle);


        // ListOf
        EditorTools.EditorSubTitle("List<int> ListOf(int from, int to)".ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("from", " Start of the list");
        EditorTools.CreateParam("to", " End of the list");
        GUILayout.Space(10);
        GUILayout.Label(
          "    <b>returns:</b> List<int> starting at <i>from</i> ending at <i>to</i> going up by one every place.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea("List<int> zeroToHundred = ListOf(0, 100);", textareaStyle);

        // GetSecondsFromEpoch
        EditorTools.EditorSubTitle("int GetSecondsFromEpoch()".ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        GUILayout.Label("    <b>returns:</b> int Amount of seconds since 1. January 1970");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea("int secondsSinceEpoch = GetSecondsFromEpoch()", textareaStyle);

        labelStyle.padding = noPadding;

        // GetSecondsFromEpoch
        EditorTools.EditorSubTitle("int GetMillisecondsFromEpoch()".ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        GUILayout.Label("    <b>returns:</b> int Amount of milliseconds since 1. January 1970");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea("int unixTime = GetMillisecondsFromEpoch()", textareaStyle);

        labelStyle.padding = noPadding;
        GUILayout.Space(25);
      }

      EditorGUILayout.EndFadeGroup();

      // Tree
      _treePanelOpen = EditorTools.ToggleableTitle("Tree", _treePanelOpen, 1.5f);
      if (EditorGUILayout.BeginFadeGroup(_treePanelOpen ? 1 : 0))
      {
        // constructor
        // todo: example
        EditorTools.EditorSubTitle("(constructor) Tree(T data, Tree<T>[] options)".ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("data", "Information stored in particular node");
        EditorTools.CreateParam("branches", "Another trees.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea("\n Work in progress \n", textareaStyle);

        labelStyle.padding = noPadding;
        GUILayout.Space(25);
      }

      EditorGUILayout.EndFadeGroup();


      // Noise
      _noisePanelOpen = EditorTools.ToggleableTitle("Noise", _noisePanelOpen, 1.5f);
      if (EditorGUILayout.BeginFadeGroup(_noisePanelOpen ? 1 : 0))
      {
        // Noise2D
        EditorTools.EditorSubTitle(
          "public static float PerlinNoise2D(int x, int y, float width, float height, float scale = 1, ulong? seed = null)"
            .ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("x","X coordinate of the point");
        EditorTools.CreateParam("y","Y coordinate of the point");
        EditorTools.CreateParam("width","max size along the X axis");
        EditorTools.CreateParam("height","max size along the Y axis");
        EditorTools.CreateParam("scale","scale of the perlin noise");
        EditorTools.CreateParam("seed","Seed used to generate the noise. Leave blank for random.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea(
          "float[,] generatedPoints = new float[width, height];\n" +
          "generatedPoints[x,y] = PerlinNoise2D(x, y, width, height, 5) // Seed was not filled in, so it is generated randomly\n"
          , textareaStyle);

        labelStyle.padding = noPadding;


        // Noise3D
        EditorTools.EditorSubTitle(
          "public static float PerlinNoise3D(int x, int y, int z, float width, float height, float depth, float scale = 1, ulong? seed = null)"
            .ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("x","X coordinate of the point");
        EditorTools.CreateParam("y","Y coordinate of the point");
        EditorTools.CreateParam("z","Y coordinate of the point");
        EditorTools.CreateParam("width","max size along the X axis");
        EditorTools.CreateParam("height","max size along the Y axis");
        EditorTools.CreateParam("depth","max size along the Z axis");
        EditorTools.CreateParam("scale","scale of the perlin noise");
        EditorTools.CreateParam("seed","Seed used to generate the noise. Leave blank for random.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea(
          "float[,,] generatedPoints = new float[width, height, depth];\n" +
          "generatedPoints[x,y,z] = PerlinNoise2D(x, y, z, width, height, depth, 5) // Seed was not filled in, so it is generated randomly\n"
          , textareaStyle);

        labelStyle.padding = noPadding;

        // Simplex2D
        EditorTools.EditorSubTitle(
          "public static double SimplexNoise2D(double x, double y, ulong? seed = null)".ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("x","X coordinate of the point");
        EditorTools.CreateParam("y","Y coordinate of the point");
        EditorTools.CreateParam("seed","Seed used to generate the noise. Leave blank for random.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea(
          "double[,] generatedPoints = new double[width, height];\n" +
          "generatedPoints[x,y] = SimplexNoise2D(x, y) // Seed was not filled in, so it is generated randomly\n"
          , textareaStyle);

        labelStyle.padding = noPadding;

        // Simplex3D
        EditorTools.EditorSubTitle(
          "public static double SimplexNoise3D(double x, double y, double z, ulong? seed = null)"
            .ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("x","X coordinate of the point");
        EditorTools.CreateParam("y","Y coordinate of the point");
        EditorTools.CreateParam("z","Z coordinate of the point");
        EditorTools.CreateParam("seed","Seed used to generate the noise. Leave blank for random.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea(
          "double[,,] generatedPoints = new double[width, height, depth];\n" +
          "generatedPoints[x,y,z] = SimplexNoise2D(x, y, z) // Seed was not filled in, so it is generated randomly\n"
          , textareaStyle);

        labelStyle.padding = noPadding;


        // Simplex4D
        EditorTools.EditorSubTitle(
          "public static double SimplexNoise4D(double x, double y, double z, double w, ulong? seed = null)"
            .ApplyCodeHighlighting());
        labelStyle.padding = subtitlePadding;
        EditorTools.CreateParam("x","X coordinate of the point");
        EditorTools.CreateParam("y","Y coordinate of the point");
        EditorTools.CreateParam("z","Z coordinate of the point");
        EditorTools.CreateParam("w","W coordinate of the point");
        EditorTools.CreateParam("seed","Seed used to generate the noise. Leave blank for random.");
        GUILayout.Space(10);
        GUILayout.Label("<b>Example</b>");
        GUILayout.TextArea(
          "double[,,,] generatedPoints = new double[width, height, depth, fourth];\n" +
          "generatedPoints[x,y,z,w] = SimplexNoise2D(x, y, z, w) // Seed was not filled in, so it is generated randomly\n"
          , textareaStyle);

        labelStyle.padding = noPadding;
        GUILayout.Space(25);
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
        GUILayout.Space(25);
      }

      EditorGUILayout.EndFadeGroup();

      GUILayout.EndScrollView();
    }
  }
}