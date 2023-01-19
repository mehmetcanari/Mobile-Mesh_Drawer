using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Voxelity.Extensions
{

    /// <summary>
    /// List extensions.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Get random item from this list.
        /// </summary>
        public static TSource RandomItem<TSource>(this IList<TSource> self)
        {
            if (self.Count == 0) throw new System.IndexOutOfRangeException("Cannot select a random item from an empty list");
            return self[Random.Range(0, self.Count)];
        }
        /// <summary>
        /// Remove random item from this list.
        /// </summary> ///
        public static TSource RemoveRandom<TSource>(this IList<TSource> self)
        {
            if (self.Count == 0) throw new System.IndexOutOfRangeException("Cannot remove a random item from an empty list");
            int index = UnityEngine.Random.Range(0, self.Count);
            TSource item = self[index];
            self.RemoveAt(index);
            return item;
        }
        /// <summary>
        /// Shuffles this list.
        /// </summary>
        public static void Shuffle<TSource>(this IList<TSource> self)
        {
            for (var i = self.Count - 1; i > 1; i--)
            {
                var j = Random.Range(0, i + 1);
                (self[j], self[i]) = (self[i], self[j]);
            }
        }
        /// <summary>
        /// For each component in an array, take an action
        /// </summary>
        /// <param name="list"></param>
        /// <param name="callback"></param>
        /// <typeparam name="TComponent"></typeparam>
        public static void ForEachComponent<TComponent>(this IList<TComponent> list, Action<TComponent> callback) where TComponent : Component
        {
            for (var i = 0; i < list.Count; i++)
            {
                callback.Invoke(list[i]);
            }
        }
        /// <summary>
        /// Replace the specified self, src and func.
        /// </summary>
        public static void Replace<TSource>(this List<TSource> self, IEnumerable<TSource> src, Func<TSource, TSource, bool> func)
        {
            if (func == null) return;
            IEnumerable<TSource> adds = src.Where(x => !self.Any(y => func(x, y)));
            IEnumerable<TSource> removes = self.Where(x => !src.Any(y => func(x, y)));
            adds.ForEach(x => self.Add(x));
            removes.ForEach(x => self.Remove(x));
        }

        /// <summary>
        /// Clears the with add range.
        /// </summary>
        public static void ClearWithAddRange<TSource>(this List<TSource> self, IEnumerable<TSource> adds)
        {
            if (adds == null) return;
            self.Clear();
            self.AddRange(adds);
        }

        /// <summary>
        /// Remove the specified self and func.
        /// </summary>
        public static void Remove<TSource>(this List<TSource> self, Func<TSource, bool> func)
        {
            if (func == null) return;
            IEnumerable<TSource> remove = self.Where(x => func(x)).ToList();
            remove.ForEach(x => self.Remove(x));
        }
    }
}