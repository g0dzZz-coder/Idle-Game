using UnityEngine;

namespace IdleGame.Entities.Buildings
{
    using People;
    using Core;

    public class Building : EntityBase<BuildingData>
    {
        [SerializeField] private BuildingView _view = default;
        [SerializeField] private InteractionTrigger _trigger = default;

        private void Start()
        {
            _view.Init(this);

            _trigger.Interaction += OnInteraction;
        }

        private void OnDestroy()
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