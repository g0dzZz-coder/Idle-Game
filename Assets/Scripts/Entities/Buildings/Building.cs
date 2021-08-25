using UnityEngine;
using System;

namespace IdleGame.Entities.Buildings
{
    using People;
    using Core;
    using Player;

    public class Building : EntityBase<BuildingData>
    {
        [SerializeField] private string _name = "Building";
        [SerializeField] private BuildingView _view = default;
        [SerializeField] private InteractionTrigger _trigger = default;

        public string Name => _name;
        public int Level { get; private set; }
        public int Reward { get; private set; }
        public int UpgradeCost { get; private set; }

        private void Start()
        {
            SetLevel(Data.levels.initialLevel);
            _view.Init(this);

            _trigger.Interaction += OnInteraction;
        }

        private void OnDestroy()
        {
            _trigger.Interaction -= OnInteraction;
        }

        public void Upgrade()
        {
            Player.DecreaseScore(UpgradeCost);
            SetLevel(Level + 1);
        }

        private void OnInteraction(Human human)
        {
            Player.IncreaseScore(Reward);
            GameLogic.Instance.OnHumanDestinationReached(human);
        }

        private void SetLevel(int index)
        {
            if (index < 1)
                throw new ArgumentOutOfRangeException();

            Level = index;
            Reward = Data.levels.initialReward + (Level - 1) * Data.levels.gainPerLevel;
            UpgradeCost = Level * Data.levels.upgradeCost;
        }
    }
}