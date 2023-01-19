using UnityEngine;
using System.IO;

namespace Voxelity.Save
{
    public static class JsonSaver
    {
        public static void Save<T>(string fileName, T data)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(fileName.WithPersistentDataPath(), json);
        }
        public static bool Exists(string fileName)
        {
            return File.Exists(fileName.WithPersistentDataPath());
        }
        public static bool Exists<T>(string fileName, out T file)
        {
            bool fileExists = File.Exists(fileName.WithPersistentDataPath());
            if (fileExists)
                file = Load<T>(fileName.WithPersistentDataPath());
            else
                file = default(T);
            return fileExists;
        }
        public static bool Delete(string fileName)
        {
            if(Exists(fileName)){
                File.Delete(fileName.WithPersistentDataPath());
                return true;
            }
            return false;
        }
        public static T Load<T>(string fileName)
        {
            string json = File.ReadAllText(fileName.WithPersistentDataPath());
            return JsonUtility.FromJson<T>(json);
        }
        private static string WithPersistentDataPath(this string fileName)
        {
            return Path.Combine(Application.persistentDataPath, fileName);
        }
    }
}

