using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IdleGame.Utils
{
    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            var random = new ThreadSafeRandom();
            var list = enumerable as IList<T> ?? enumerable.ToList();
            return list.ElementAt(random.Next(0, list.Count()));
        }

        public static float GetClosestDistance<T>(this IEnumerable<T> enumerable, Vector3 position) where T : Component
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            var closest = Mathf.Infinity;
            foreach (var enemy in enumerable)
            {
                if (enemy == null)
                    continue;

                var distance = Vector3.Distance(enemy.transform.position, position);
                if (distance < closest)
                {
                    closest = distance;
                }
            }

            return closest;
        }
    }
}