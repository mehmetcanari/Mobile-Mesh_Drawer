using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Voxelity.Editor
{
    public static class VoxelityEditor
    {
        private const string defineName = "VOXELITY_CORE";
#if !VOXELITY_CORE
        [InitializeOnLoadMethod]
        private static void AddDefine()
        {
            AddDefine(defineName);
        }
        private static void AddDefine(string defineName)
        {
            string currentDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            if (!currentDefines.Contains(defineName))
            {
                currentDefines += ";" + defineName;
                PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, currentDefines);
                Debug.Log("Custom define added successfully.");
            }
            else
            {
                Debug.Log("Custom define already exist.");
            }
        }
#endif


        public static T GetOrCreateScriptableObject<T>(string path) where T : ScriptableObject
        {
            var so = AssetDatabase.LoadAssetAtPath<T>(path);
            if (so == null)
            {
                so = ScriptableObject.CreateInstance<T>();
                AssetDatabase.CreateAsset(so, path);
                AssetDatabase.SaveAssets();
            }
            return so;
        }
        public static string GetPath(string path, bool isObject = false)
        {
            string[] folderPaths = path.Split('/');

            string _path = folderPaths[0];

            if (isObject)
                folderPaths[folderPaths.Length - 1] = "";

            for (int i = 1; i < folderPaths.Length; i++)
            {
                _path = CreateFolder(_path, folderPaths[i]);
            }
            return _path;
        }
        public static string CreateFolder(string path, string folderName)
        {
            if (folderName == "") return path;

            if (!AssetDatabase.IsValidFolder(path + "/" + folderName))
                AssetDatabase.CreateFolder(path, folderName);

            return path + "/" + folderName;
        }
        public static List<T> FindAssets<T>(params string[] paths) where T : Object
        {
            string[] assetGUIDs = AssetDatabase.FindAssets("t:" + typeof(T), paths);
            List<T> assets = new List<T>();
            foreach (string guid in assetGUIDs)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                assets.Add(asset);
            }
            return assets;
        }
    }
}