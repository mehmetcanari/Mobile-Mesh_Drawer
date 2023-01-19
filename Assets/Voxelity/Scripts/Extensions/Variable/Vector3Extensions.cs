using UnityEngine;

namespace Voxelity.Extensions
{
    /// <summary>
    /// Vector3 extensions.
    /// </summary>
    public static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 val, float x) => new Vector3(x, val.y, val.z);
        public static Vector3 WithY(this Vector3 val, float y) => new Vector3(val.x, y, val.z);
        public static Vector3 WithZ(this Vector3 val, float z) => new Vector3(val.x, val.y, z);
        public static Vector3 With(this Vector3 val, float? x = null, float? y = null, float? z = null) => new Vector3(x ?? val.x, y ?? val.y, z ?? val.z);
        public static Vector3 Flat(this Vector3 input, float yValue = 0) => new Vector3(input.x, yValue, input.z);
        public static Vector3Int ToVector3Int(this Vector3 input) => new Vector3Int((int)input.x, (int)input.y, (int)input.z);
        public static Vector2 ToV2(this Vector3 val) => new Vector2(val.x, val.y);
        public static Vector3 DirectionTo(this Vector3 source, Vector3 destination) => Vector3.Normalize(destination - source);
        public static string Vector3ToString(this Vector3 self) => $"{self.x}~{self.y}~{self.z}";

        public static Vector3 Divide(this Vector3 source, Vector3 dividedWith) => new Vector3(source.x / dividedWith.x,
            source.y / dividedWith.y, source.z / dividedWith.z);

        public static Vector3 half => new Vector3(0.5f, 0.5f, 0.5f);
    }
}