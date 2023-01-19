using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Voxelity.SO
{
    public class VoxelitySettings : ScriptableObject
    {
        #if UNITY_EDITOR
        public const string k_VoxelitySettingsPathInPackage = "Packages/co.voxelstudio.voxelity/Voxelity/Resources/VoxelitySettings.asset";
        public static VoxelitySettings GetOrCreateSettings()
        {
            var settings = AssetDatabase.LoadAssetAtPath<VoxelitySettings>(k_VoxelitySettingsPathInPackage);
            if (settings == null)
            {
                settings = ScriptableObject.CreateInstance<VoxelitySettings>();
                AssetDatabase.CreateAsset(settings, k_VoxelitySettingsPathInPackage);
                AssetDatabase.SaveAssets();
            }
            return settings;
        }
        #endif
    }
}