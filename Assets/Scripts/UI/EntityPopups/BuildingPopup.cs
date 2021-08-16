using TMPro;
using UnityEngine;

namespace IdleGame.UI
{
    using Entities.Buildings;
    using UnityEngine.UI;

    public class BuildingPopup : EntityPopupBase
    {
        [SerializeField] private TMP_Text _nameText = default;
        [SerializeField] private TMP_Text _levelText = default;
        [SerializeField] private Button _upgradeButton = default;

        private Building _current;

        private void Awake()
        {
            //_upgradeButton.onClick.AddListener(TryToUpdgrateSelected);
            Root.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            //_upgradeButton.onClick.RemoveListener(TryToUpdgrateSelected);
        }

        public void Show(Building building)
        {
            _current = building;
            //_nameText.text = building.name;
            // _levelText.text = 0.ToString();

            Show();
        }

        private void TryToUpdgrateSelected()
        {

        }
    }
}