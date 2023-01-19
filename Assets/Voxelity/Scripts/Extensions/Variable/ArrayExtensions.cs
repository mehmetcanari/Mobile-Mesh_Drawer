using System;
using UnityEngine;

namespace Voxelity.Extensions
{
    public static class ArrayExtensions
    {
        public static void ForEach<TSource>(this TSource[] self, Action<TSource> func)
        {
            if (func == null)
            {
                return;
            }

            foreach (TSource row in self)
            {
                func(row);
            }
        }

        /// <summary>
        /// For each component in an array, take an action
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="self"></param>
        /// <param name="callback">The action to take</param>
        public static void ForEachComponent<TComponent>(this TComponent[] self, Action<TComponent> callback)
            where TComponent : Component
        {
            for (var i = 0; i < self.Length; i++)
            {
                callback.Invoke(self[i]);
            }
        }
    }
}