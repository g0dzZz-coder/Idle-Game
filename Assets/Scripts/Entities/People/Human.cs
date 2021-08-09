using UnityEngine;

namespace IdleGame.Entities.Human
{
    public class Human : EntityBase<HumanData>
    {
        private void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}