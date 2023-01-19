using UnityEngine;

namespace Voxelity
{
    public interface IVoxelityUser
    {
        public MonoBehaviour GetMono => (MonoBehaviour)this;
    }
}
