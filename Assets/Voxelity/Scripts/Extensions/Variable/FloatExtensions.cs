using UnityEngine;

namespace Voxelity.Extensions
{
    public static class FloatExtensions
    {
        public static bool ApproxEquals(this float f, float f2) => Mathf.Approximately(f, f2);
        public static int ToInt(this float _arg) => Mathf.RoundToInt(_arg);
        public static Vector3 ToV3(this float input) => Vector3.one * input;
    }
}