using UnityEngine;

namespace IdleGame.Selection
{
    internal interface ISelectionResponse
    {
        void OnSelect(Transform selection);
        void OnDeselect(Transform selection);
    }
}