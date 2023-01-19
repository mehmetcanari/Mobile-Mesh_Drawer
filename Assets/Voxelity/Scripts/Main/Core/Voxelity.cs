using UnityEngine;

namespace Voxelity
{
    public static class Voxelity
    {
        public static VoxelityManager Manager;
        [RuntimeInitializeOnLoadMethod]
        private static void CreateVoxelity()
        {
            GameObject voxelityObject = new GameObject("~Voxelity~");
            Manager = voxelityObject.AddComponent<VoxelityManager>();
            voxelityObject.hideFlags = HideFlags.NotEditable;
        }
    }
}
