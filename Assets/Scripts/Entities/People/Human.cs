using UnityEngine;

namespace IdleGame.Entities.Human
{
    using Utils;

    public class Human : EntityBase<HumanData>
    {
        [SerializeField] private HumanMovement _movement = default;

        public HumanMovement Movement => _movement;

        private void Start()
        {
            ComponentStorage.Add(this);
        }

        private void OnDestroy()
        {
            ComponentStorage.Remove(this);
            Destroyed?.Invoke(this);
        }
    }
}