using UnityEngine.EventSystems;

namespace IdleGame.Entities.Buildings
{
    public class BuildingView : EntityViewBase, IPointerDownHandler
    {
        private Building _building;

        public void Init(Building building)
        {
            _building = building;
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }
    }
}