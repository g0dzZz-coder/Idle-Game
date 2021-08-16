using UnityEngine;
using UnityEngine.AI;

namespace IdleGame.Entities
{
    public class HumanMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent = default;

        private Vector3 _startPoint;

        private void Start()
        {
            _startPoint = transform.position;
        }

        public void SetTarget(Vector3 targetPosition)
        {
            _agent.SetDestination(targetPosition);
        }

        public void ReturnToStartPoint()
        {
            _agent.SetDestination(_startPoint);
        }

        private void Reset()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
    }
}