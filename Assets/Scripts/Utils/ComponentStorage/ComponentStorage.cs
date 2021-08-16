using System;
using System.Collections.Generic;
using UnityEngine;

namespace IdleGame.Utils
{
    /// <summary>
    /// A class that stores all the components that you give it. Needed in order to get rid of GetComponent 
    /// </summary>
    public static class ComponentStorage
    {
        private static Dictionary<Type, BaseComponentSaver> Storage = new Dictionary<Type, BaseComponentSaver>();

        /// <summary>
        /// Add created component
        /// </summary>
        /// <param name="element">Component</param>
        /// <typeparam name="T">Type at componente (MonoBeh)</typeparam>
        public static void Add<T>(T element) where T : MonoBehaviour
        {
            var t = typeof(T);

            if (Storage.TryGetValue(t, out var saver))
            {
                var se = saver as ComponentSaver<T>;
                se.Add(element);
            }
            else
            {
                Storage.Add(t, new ComponentSaver<T>());
                (Storage[t] as ComponentSaver<T>).Add(element);
            }
        }

        /// <summary>
        /// return GameObject ID
        /// </summary>
        /// <param name="go">GameObject</param>
        /// <returns>GameObject ID</returns>
        private static string GetId(GameObject go) => go.GetInstanceID().ToString();

        /// <summary>
        /// Get saved component
        /// </summary>
        /// <param name="go">GameObject</param>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component</returns>
        public static T GetElement<T>(GameObject go) where T : MonoBehaviour => GetElement<T>(GetId(go));

        /// <summary>
        /// Get saved component
        /// </summary>
        /// <param name="go">GameObject component</param>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component</returns>
        public static T GetElement<T>(Component go) where T : MonoBehaviour => GetElement<T>(GetId(go.gameObject));

        /// <summary>
        /// Get saved component
        /// </summary>
        /// <param name="id">GameObject ID</param>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns>Component</returns>
        public static T GetElement<T>(string id) where T : MonoBehaviour
        {
            var t = typeof(T);

            if (Storage.TryGetValue(t, out var saver))
            {
                var se = saver as ComponentSaver<T>;
                return se.GetElement(id);
            }

            return null;
        }

        /// <summary>
        /// Remove saved component
        /// </summary>
        /// <param name="go">Component</param>
        /// <typeparam name="T">Component type</typeparam>
        public static void Remove<T>(T go) where T : MonoBehaviour => Remove<T>(GetId(go.gameObject));

        /// <summary>
        /// Remove saved component
        /// </summary>
        /// <param name="go">GameObject component</param>
        /// <typeparam name="T">Component type</typeparam>
        public static void Remove<T>(GameObject go) where T : MonoBehaviour => Remove<T>(GetId(go));

        /// <summary>
        /// Remove saved component
        /// </summary>
        /// <param name="go">Other component</param>
        /// <typeparam name="T">Component type</typeparam>
        public static void Remove<T>(Component go) where T : MonoBehaviour => Remove<T>(GetId(go.gameObject));

        /// <summary>
        /// Remove saved component
        /// </summary>
        /// <param name="id">Component ID</param>
        /// <typeparam name="T">Component type</typeparam>
        public static void Remove<T>(string id) where T : MonoBehaviour
        {
            var t = typeof(T);
            if (Storage.TryGetValue(t, out var saver))
            {
                var se = saver as ComponentSaver<T>;
                se.Remove(id);
            }
        }
    }
}