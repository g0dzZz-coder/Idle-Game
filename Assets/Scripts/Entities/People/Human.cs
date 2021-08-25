using UnityEngine;

namespace IdleGame.Entities.People
{
    using Utils;

    public class Human : EntityBase<HumanData>
    {
        [SerializeField] private HumanMovement _movement = default;
        [SerializeField] private HumanView _view = default;

        public bool IsMissionCompleted { get; private set; }

        private void Start()
        {
            ComponentStorage.Add(this);
            _movement.Init(this);
        }

        private void OnDestroy()
        {
            ComponentStorage.Remove(this);
            Destroyed?.Invoke(this);
        }

        public void SetMissionTarget(Vector3 position)
        {
            IsMissionCompleted = false;
            _movement.SetTarget(position);
        }

        public void CompleteMission()
        {
            IsMissionCompleted = true;
            _movement.ReturnToStartPoint();
        }

        public void DestroySelf()
        {
            _view.OnDestroying(() => Destroy(gameObject));
        }
    }
}