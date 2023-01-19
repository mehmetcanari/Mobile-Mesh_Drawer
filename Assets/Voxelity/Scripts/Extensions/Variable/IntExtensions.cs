namespace Voxelity.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns bool value for given int value. 0 returns false, 1 returns true. Any other values other than 1 returns false.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this int value) => value == 1;

        /// <summary>
        /// Get mode of the value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static int Mode(this int value, int mode) => value % mode;
    }
}