using System.Collections.Generic;
using UnityEngine;

namespace IdleGame.Utils
{
    public class ComponentSaver<T> : BaseComponentSaver where T : MonoBehaviour
    {
        public Dictionary<string, T> components = new Dictionary<string, T>();

        public void Add(T element)
        {
            var id = element.gameObject.GetInstanceID().ToString();
            if (components.ContainsKey(id) == false)
                components.Add(id, element);
        }

        public T GetElement(string ID)
        {
            if (components.TryGetValue(ID, out T element))
                return element;

            return null;
        }

        public void Remove(string ID)
        {
            if (components.TryGetValue(ID, out T element))
                components.Remove(ID);
        }
    }

    public class BaseComponentSaver
    {

    }
}