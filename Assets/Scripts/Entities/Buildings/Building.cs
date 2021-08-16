using UnityEngine;

namespace IdleGame.Entities.Buildings
{
    using People;
    using Core;

    public class Building : EntityBase<BuildingData>
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
            Player.Player.IncreaseScore(1);
            GameLogic.Instance.OnHumanDestinationReached(human);
        }
    }
}