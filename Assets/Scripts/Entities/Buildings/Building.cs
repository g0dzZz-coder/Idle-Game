using UnityEngine;

namespace IdleGame.Entities.Buildings
{
    using Human;
    using Core;

    public class Building : MonoBehaviour
    {
        [SerializeField] private InteractionTrigger _trigger = default;

        private void OnEnable()
        {
            _trigger.Interaction += OnInteraction;
        }

        private void OnDisable()
        {
            _trigger.Interaction -= OnInteraction;
        }

        private void OnInteraction(Human human)
        {
            GameLogic.Instance.OnHumanInteractionWithBuildingStarted(human, this);
        }
    }
}