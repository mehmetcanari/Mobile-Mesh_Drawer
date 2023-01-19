using UnityEngine;


namespace Voxelity
{
    /// <summary>
    /// Makes the class singleton. 
    /// Singletons can't be multiple there should be only 1 of them. 
    /// Any defined class can reach them by using ExampleSingletonClass.Instance
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        private static object lockObject = new object();

        public static T Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = (T)FindObjectOfType(typeof(T));

                        if (instance == null)
                        {
                            GameObject singletonObject = new GameObject();
                            instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";
                        }
                    }

                    return instance;
                }
            }
        }
    }
}