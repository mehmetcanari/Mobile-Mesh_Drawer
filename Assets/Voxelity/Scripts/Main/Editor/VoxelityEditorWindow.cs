using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Voxelity.Editor
{
    public class VoxelityEditorWindow : EditorWindow
    {
        public delegate void OnGUIMethod();
        public static List<OnGUIMethod> OnGUIMethods = new List<OnGUIMethod>();

        public void OnInspectorGUI()
        {
            foreach (OnGUIMethod onGUIMethod in OnGUIMethods)
            {
                onGUIMethod.Invoke();
            }
        }
        [MenuItem("Voxelity/Settings Window", priority = -100)]
        public static void ShowWindow()
        {
            VoxelityEditorWindow window = GetWindow<VoxelityEditorWindow>("Voxelity");
            Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Packages/co.voxelstudio.voxelity/Voxelity/Icons/Voxel Icon/voxel_logo_green.png");
            GUIContent titleContent = new GUIContent("Voxelity", icon);
            window.titleContent = titleContent;
        }
        public void OnGUI()
        {
            OnInspectorGUI();
        }
    }
}