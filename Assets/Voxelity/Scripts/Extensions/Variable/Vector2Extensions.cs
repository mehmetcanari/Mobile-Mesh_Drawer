using UnityEngine;

namespace Voxelity.Extensions
{
    /// <summary>
    /// Vector2 extensions
    /// </summary>
    public static class Vector2Extensions
    {
        public static Vector2 With(this Vector2 self, float? x = null, float? y = null, float? z = null) => new Vector2(x ?? self.x, y ?? self.y);
        public static Vector2 WithX(this Vector2 self, float x) => new Vector2(x, self.y);
        public static Vector2 WithY(this Vector2 self, float y) => new Vector2(self.x, y);

        public static Vector2Int With(this Vector2Int self, int? x = null, int? y = null, int? z = null) => new Vector2Int(x ?? self.x, y ?? self.y);
        public static Vector2Int WithX(this Vector2Int self, int x) => new Vector2Int(x, self.y);
        public static Vector2Int WithY(this Vector2Int self, int y) => new Vector2Int(self.x, y);

        public static Vector3 ToV3(this Vector2 self, float z = 0) => new Vector3((float)self.x, (float)self.y, z);
        public static string Vector2ToString(this Vector2 self) => $"{self.x}~{self.y}";

    }
}