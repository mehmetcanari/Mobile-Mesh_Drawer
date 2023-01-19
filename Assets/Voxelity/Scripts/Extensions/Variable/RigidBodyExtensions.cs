using UnityEngine;


namespace Voxelity.Extensions
{
    /// <summary>
    /// Rigidbody extensions.
    /// </summary>
    public static class RigidBodyExtensions
    {
        public static void ChangeDirection(this Rigidbody self, Vector3 direction)
        {
            self.velocity = direction.normalized * self.velocity.magnitude;
        }
        public static void NormalizeVelocity(this Rigidbody self, float magnitude = 1)
        {
            self.velocity = self.velocity.normalized * magnitude;
        }
    }
}