using UnityEngine;

namespace IdleGame.Spawning
{
    public class HumanSpawnZone : MonoBehaviour
    {
        [SerializeField] private float _radius = 3f;
        [SerializeField] private Color _gizmosColor = new Color(0, 255, 0, 0.2f);

        public Vector3 GetRandomPosition()
        {
            var position = transform.position + Random.insideUnitSphere * _radius;
            position.y = 0f;

            return position;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}