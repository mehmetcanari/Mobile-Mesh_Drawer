namespace Voxelity.Extensions
{
    /// <summary>
    /// Bool extensions.
    /// </summary>
    public static class BoolExtensions
    {
        /// <summary>
        /// Returns int for given bool value. false returns 0, true returns 1.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this bool value) => value ? 1 : 0;

        /// <summary>
        /// Returns reverse of the bool.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Reverse(this bool value) => !value;
    }
}