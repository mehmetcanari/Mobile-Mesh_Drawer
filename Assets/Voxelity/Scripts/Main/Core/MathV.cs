using UnityEngine;

namespace Voxelity
{
    public static class MathV
    {
        /// <summary>
        /// Returns any given value as negative.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float NegativeAbs(float value)
        {
            return -Mathf.Abs(value);
        }
        /// <summary>
        /// Returns 0 to 1 percentage from given values.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float GetPercentage(float value, float min = 0, float max = 100)
        {
            return (value - min) / (max - min);
        }

        /// <summary>
        /// Basic multipication between 2 Vector3's.
        /// </summary>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public static Vector3 MultiplyVector3s(Vector3 arg0, Vector3 arg1) => new Vector3(arg0.x * arg1.x, arg0.y * arg1.y, arg0.z * arg1.z);
        /// <summary>
        /// Combine collor array    
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static Color CombineColors(params Color[] colors)
        {
            Color result = new Color(0,0,0,0);
            foreach(Color c in colors)
            {
                result += c;
            }
            result /= colors.Length;
            return result;
        }
    }
}
