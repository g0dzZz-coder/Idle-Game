using UnityEngine;

namespace IdleGame.Selection
{
    public class RayCastBasedTagSelector : MonoBehaviour, ISelector
    {
        [SerializeField] private string _selectableTag = "Selectable";

        private Transform _selection;

        public void Check(Ray ray)
        {
            _selection = null;

            if (Physics.Raycast(ray, out var hit) == false) 
                return;

            var selection = hit.transform;
            if (selection.CompareTag(_selectableTag))
            {
                _selection = selection;
            }
        }

        public Transform GetSelection()
        {
            return _selection;
        }
    }
}