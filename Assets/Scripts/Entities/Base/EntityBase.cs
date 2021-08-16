using System;
using UnityEngine;

namespace IdleGame.Entities
{
    public class EntityBase<T> : MonoBehaviour where T : EntityData
    {
        [SerializeField] T _data = default;

        public T Data => _data;

        public Action<EntityBase<T>> Destroyed { get; set; }
    }
}