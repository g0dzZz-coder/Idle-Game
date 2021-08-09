using System;
using UnityEngine;

namespace IdleGame.Entities
{
    public class EntityBase<T> : MonoBehaviour
    {
        public Action<EntityBase<T>> Destroyed { get; set; }
    }
}