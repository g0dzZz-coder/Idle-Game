using UnityEngine;
using UnityEngine.AI;

namespace IdleGame.Entities.People
{
    using Utils;

    public class HumanMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent = default;

        private Vector3 _startPoint;
        private IOnHumanDestinationReachedWatcher[] _watchers;
        private Human _human;

        private void Awake()
        {
            _watchers = RootProvider.Instance.Root.GetComponentsInChildren<IOnHumanDestinationReachedWatcher>();
        }

        public void Init(Human human)
        {
            _human = human;
            _startPoint = transform.position;
        }

        private void Update()
        {
            if (IsDestinationReached() == false)
                return;

            EmitOnHumanDestinationReached(_human);
        }

        public void SetTarget(Vector3 targetPosition)
        {
            _agent.SetDestination(targetPosition);
        }

        public void ReturnToStartPoint()
        {
            _agent.SetDestination(_startPoint);
        }

        private void EmitOnHumanDestinationReached(Human human)
        {
            foreach (var watcher in _watchers)
                watcher.OnHumanDestinationReached(human);
        }

        private bool IsDestinationReached()
        {
            if (_agent.isStopped)
                return false;

            if (_agent.remainingDistance <= _agent.stoppingDistance)
                return true;

            return false;
        }

        private void Reset()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
    }
}