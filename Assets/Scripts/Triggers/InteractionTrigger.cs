using System;
using UnityEngine;

namespace IdleGame
{
    using Entities.Human;
    using Utils;

    public class InteractionTrigger : Trigger
    {
        public event Action<Human> Interaction;

        protected override void OnTriggerEntered(Collider collider)
        {
            var human = ComponentStorage.GetElement<Human>(collider.gameObject);
            if (human == null)
                return;

            Interact(human);
        }

        private void Interact(Human human)
        {
            Interaction?.Invoke(human);
        }
    }
}