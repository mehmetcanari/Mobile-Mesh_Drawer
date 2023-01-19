using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Voxelity
{
    [System.Serializable]
    public class VoxelityManager : Singleton<VoxelityManager>
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        public List<IVoxelityUser> GetVoxelityUsers()
        {
            var voxelityUsers = FindObjectsOfType<MonoBehaviour>().OfType<IVoxelityUser>();
            return voxelityUsers.ToList();
        }
    }
}
