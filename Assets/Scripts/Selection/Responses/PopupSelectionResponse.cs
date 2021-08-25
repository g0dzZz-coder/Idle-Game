using IdleGame.Entities.Buildings;
using UnityEngine;
using UnityEngine.Events;

namespace IdleGame.Selection
{
    public class PopupSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        [SerializeField] private UnityEvent<Building> _onSelected = new UnityEvent<Building>();
        [SerializeField] private UnityEvent _onDeselected = new UnityEvent();

        public void OnDeselect(Transform selection)
        {
            _onDeselected?.Invoke();
        }

        public void OnSelect(Transform selection)
        {
            if (selection.TryGetComponent(out Building building))
                OpenBuildingPopup(building);
        }

        private void OpenBuildingPopup(Building building)
        {
            _onSelected?.Invoke(building);
        }
    }
}