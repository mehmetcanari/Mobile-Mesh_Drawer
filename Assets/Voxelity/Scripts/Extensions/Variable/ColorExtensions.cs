using UnityEngine;

namespace Voxelity.Extensions
{
    /// <summary>
    /// Color extensions.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Returns Hex code with # of the Color.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToHex(this Color self) => "#" + ColorUtility.ToHtmlStringRGB(self);
        /// <summary>
        /// Returns new Color with same RGBA parameters after changing given r,g,b,a values.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Color With(this Color self, float? r = null, float? g = null, float? b = null, float? a = null) => new Color(r ?? self.r, g ?? self.g, b ?? self.b, a ?? self.a);
        /// <summary>
        /// Returns a new Color with same gba values with given r value. 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Color WithR(this Color self, float r) => new Color(r, self.g, self.b, self.a);
        /// <summary>
        /// Returns a new Color with same gba values with given r value. 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        public static Color WithG(this Color self, float g) => new Color(self.r, g, self.b, self.a);
        /// <summary>
        /// Returns a new Color with same gba values with given r value. 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Color WithB(this Color self, float b) => new Color(self.r, self.g, b, self.a);
        /// <summary>
        /// Returns a new Color with same gba values with given r value. 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Color WithA(this Color self, float a) => new Color(self.r, self.g, self.b, a);
        /// <summary>
        /// Gets a random color.
        /// </summary>

        public static Color random => new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}