using UnityEngine;
using UnityEngine.Assertions;

namespace IdleGame.Selection
{
    public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
    {
        [SerializeField] private Camera _camera = default;

        private void Start()
        {
            Assert.IsNotNull(_camera);
        }

        public Ray CreateRay()
        {
            return _camera.ScreenPointToRay(Input.mousePosition);
        }
    }
}