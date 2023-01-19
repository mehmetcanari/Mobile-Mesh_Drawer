using System.IO;
namespace Voxelity.Extensions
{
    public static class TextWriterExtensions
    {
        public static void WriteLineLF(this TextWriter self, object value)
        {
            self.Write(value);
            self.Write("\n");
        }
    }
}