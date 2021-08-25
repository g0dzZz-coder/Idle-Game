using TMPro;
using UnityEngine;

namespace IdleGame.UI
{
    using Entities.Buildings;
    using Player;

    public class BuildingPopup : EntityPopupBase
    {
        [SerializeField] private TMP_Text _nameText = default;
        [SerializeField] private TMP_Text _levelText = default;
        [SerializeField] private TMP_Text _nextLevelCostText = default;
        [SerializeField] private TMP_Text _rewardText = default;
        [SerializeField] private HoldButton _upgradeButton = default;

        private Building _current;

        private void Awake()
        {
            Root.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (isActiveAndEnabled == false || _current == null)
                return;

            if (Player.Score < _current.UpgradeCost)
                _upgradeButton.Disable();
            else
                _upgradeButton.Enable();
        }

        public void Show(Building building)
        {
            _current = building;
            UpdateInfo();

            _upgradeButton.SetFillingColor(_current.View.Color);
            Show();
        }

        public void TryToUpdgrateSelected()
        {
            if (_current == null)
                return;

            _current.Upgrade();
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            UpdateName(_current.Name);
            UpdateLevel(_current.Level);
            UpdateNextLevelCost(_current.UpgradeCost);
            UpdateReward(_current.Reward);
        }

        private void UpdateName(string name)
        {
            _nameText.text = name;
        }

        private void UpdateLevel(int level)
        {
            if (_levelText)
            {
                _levelText.text = level.ToString();
                return;
            }

            _nameText.text += $" [{level}]";
        }

        private void UpdateNextLevelCost(int cost)
        {
            if (_nextLevelCostText == null)
                return;

            _nextLevelCostText.text = cost.ToString();
        }

        private void UpdateReward(int reward)
        {
            if (_rewardText == null)
                return;

            _rewardText.text = reward.ToString();
        }
    }
}