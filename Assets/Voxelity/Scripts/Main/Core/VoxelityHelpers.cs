using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Voxelity
{
    public static class VoxelityHelpers
    {
        private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
        /// <summary>
        /// The GetWait function either creates a new WaitForSeconds object or retrieves a previously created one from memory, 
        /// depending on whether it has already been created.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static WaitForSeconds GetWait(float time)
        {
            if (WaitDictionary.ContainsKey(time))
                return WaitDictionary[time];

            WaitDictionary[time] = new WaitForSeconds(time);
            return WaitDictionary[time];
        }

        private static readonly Dictionary<string, Hash128> hashes = new Dictionary<string, Hash128>();
        /// <summary>
        /// Converts string value to Hash and returns it as string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetHashString(string value)
        {
            if (hashes.ContainsKey(value))
            {
                Debug.LogWarning("Duplicate Hash Careful");
                return hashes[value].ToString();
            }

            Hash128 hash = new Hash128();
            hash.Append(value);
            hashes[value] = hash;
            return hash.ToString();
        }
        public static List<T> Find<T>(  )
         {
             List<T> interfaces = new List<T>();
             GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
             foreach( var rootGameObject in rootGameObjects )
             {
                 T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>();
                 foreach( var childInterface in childrenInterfaces )
                 {
                     interfaces.Add(childInterface);
                 }
             }
             return interfaces;
         }
    }
}