using UnityEngine;

namespace IdleGame.Entities.Buildings
{
    public class BuildingView : EntityViewBase
    {
        [SerializeField] private Color _color = Color.cyan;

        public Color Color => _color;
    }
}