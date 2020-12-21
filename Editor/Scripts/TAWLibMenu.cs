using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEditor.PackageManager;
using UnityEngine.Rendering;

namespace TheAshenWolf.Editor
{
    public class TawLibMenu : EditorWindow
    {
        private static bool _updateOnStartup = false;
        private static bool _useShaders = false;
        private static bool _useVfx = false;
        public static bool hasRenderPipeline = false;

        // Add menu item named "My Window" to the Window menu
        private const string PATH_MANUAL_UPDATE = "Tools/TheAshenWolfLib/Update";

        [MenuItem(PATH_MANUAL_UPDATE, false, 0)]
        public static void UpdatePackage()
        {
            Client.Add("https://github.com/Pozitrone/TheAshenWolfLib.git");
            if (EditorPrefs.GetBool(PATH_USE_SHADERS))
            {
                Client.Add("https://github.com/Pozitrone/TheAshenWolfShaders.git");
            }

            if (EditorPrefs.GetBool(PATH_USE_VFX))
            {
                Client.Add("https://github.com/Pozitrone/TheAshenWolfVFX.git");
            }
        }


        public const string PATH_AUTO_UPDATE = "Tools/TheAshenWolfLib/Auto update on startup";

        [MenuItem(PATH_AUTO_UPDATE, false, 0)]
        private static void UpdateOnStartup()
        {
            // Toggling action
            ToggleStartupUpdate(!TawLibMenu._updateOnStartup);
        }

        private static void ToggleStartupUpdate(bool enabled)
        {
            // Set checkmark on menu item
            Menu.SetChecked(PATH_AUTO_UPDATE, enabled);
            // Saving editor state
            EditorPrefs.SetBool(PATH_AUTO_UPDATE, enabled);

            TawLibMenu._updateOnStartup = enabled;
        }


        private const string PATH_DOCUMENTATION = "Tools/TheAshenWolfLib/Show Documentation";

        [MenuItem(PATH_DOCUMENTATION, false, 100)]
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


        private const string PATH_DEPENDENCIES = "Tools/TheAshenWolfLib/Display Dependencies";

        [MenuItem(PATH_DEPENDENCIES, false, 100)]
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


        private const string PATH_CREDITS = "Tools/TheAshenWolfLib/Credits";

        [MenuItem(PATH_CREDITS, false, 200)]
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

        public const string PATH_USE_VFX = "Tools/TheAshenWolfLib/TheAshenWolf VFX";

        [MenuItem(PATH_USE_VFX, false, 400)]
        private static void UseVfx()
        {
            // Toggling action
            ToogleUseVfx(!TawLibMenu._useVfx);
        }
        
        [MenuItem(PATH_USE_VFX, true)]
        private static bool CanRunVfx()
        {
            return hasRenderPipeline;
        }

        private static void ToogleUseVfx(bool enabled)
        {
            // Set checkmark on menu item
            Menu.SetChecked(PATH_USE_VFX, enabled);
            // Saving editor state
            EditorPrefs.SetBool(PATH_USE_VFX, enabled);
            if (enabled) Client.Add("https://github.com/Pozitrone/TheAshenWolfVFX.git");
            TawLibMenu._useVfx = enabled;
        }

        private const string PATH_USE_SHADERS = "Tools/TheAshenWolfLib/TheAshenWolf Shaders";

        [MenuItem(PATH_USE_SHADERS, false, 400)]
        private static void UseShaders()
        {
            // Toggling action
            ToggleUseShaders(!TawLibMenu._useShaders);
        }

        [MenuItem(PATH_USE_SHADERS, true)]
        private static bool CanRunShaders()
        {
            return hasRenderPipeline;
        }

        private static void ToggleUseShaders(bool enabled)
        {
            // Set checkmark on menu item
            Menu.SetChecked(PATH_USE_SHADERS, enabled);
            // Saving editor state
            EditorPrefs.SetBool(PATH_USE_SHADERS, enabled);
            if (enabled) Client.Add("https://github.com/Pozitrone/TheAshenWolfShaders.git");
            TawLibMenu._useShaders = enabled;
        }
    }

    [InitializeOnLoad]
    public class AutomaticUpdate
    {
        static AutomaticUpdate()
        {
            // Automatic update
            if (EditorPrefs.GetBool(TawLibMenu.PATH_AUTO_UPDATE))
            {
                TawLibMenu.UpdatePackage();
            }
            
            TawLibMenu.hasRenderPipeline = (GraphicsSettings.renderPipelineAsset != null);
        }
    }
}