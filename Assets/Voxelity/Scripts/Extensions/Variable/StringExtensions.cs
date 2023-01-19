using System;
using System.Collections.Generic;
using UnityEngine;

namespace Voxelity.Extensions
{
    /// <summary>
    /// String extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts string to Vector2
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Vector2 ToV2(this string self)
        {
            Vector2 returned = new Vector2();
            string[] temp = self.Split('~');
            if (temp.Length > 1)
            {
                returned.x = float.Parse(temp[0]);
                returned.y = float.Parse(temp[1]);
            }
            return returned;
        }
        public static Vector3 ToV3(this string self)
        {
            Vector3 returned = new Vector3();
            string[] temp = self.Split('~');
            if (temp.Length > 2)
            {
                returned.x = float.Parse(temp[0]);
                returned.y = float.Parse(temp[1]);
                returned.z = float.Parse(temp[2]);
            }
            else if(temp.Length > 1)
            {
                returned.x = float.Parse(temp[0]);
                returned.y = float.Parse(temp[1]);
            }
            return returned;
        }
        /// <summary>
        /// Divide a character string by the specified number of characters.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<string> SubstringAtCount(this string self, int count)
        {
            var result = new List<string>();
            var length = (int)Math.Ceiling((double)self.Length / count);

            for (int i = 0; i < length; i++)
            {
                int start = count * i;
                if (self.Length <= start)
                {
                    break;
                }
                if (self.Length < start + count)
                {
                    result.Add(self.Substring(start));
                }
                else
                {
                    result.Add(self.Substring(start, count));
                }
            }
            return result;
        }
        public static string GetLast(this string self, int tail)
        {
            if (tail >= self.Length)
                return self;
            return self.Substring(self.Length - tail);
        }

        public static bool TryParseToColor(this string self, out Color color)
        {
            if (self[0] != '#') self = "#" + self;
            if (ColorUtility.TryParseHtmlString(self, out color))
            {
                return true;
            }
            Debug.LogWarning($"Couldn't parse the string ({self.Colorize(Color.white)}) to " +
                             "c".Colorize(Color.red) + "o".Colorize(Color.yellow) + "l".Colorize(Color.green) + "o".Colorize(Color.cyan)
                             + "r".Colorize(Color.blue));
            return false;
        }

        public static string Colorize(this string self, Color color) => $"<color={color.ToHex()}>" + self + $"</color>";
        public static string Colorize(this string self, Gradient gradient)
        {
            string coloredSelf = "";
            for (int i = 0; i < self.Length; i++)
            {
                coloredSelf += self[i].ToString().Colorize(gradient.Evaluate((float)i / ((float)self.Length - 1f)));
            }

            return coloredSelf;
        }

    }
}