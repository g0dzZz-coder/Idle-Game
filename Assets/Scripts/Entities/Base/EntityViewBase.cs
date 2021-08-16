using DG.Tweening;
using UnityEngine;

namespace IdleGame.Entities
{
    public abstract class EntityViewBase : MonoBehaviour
    {
        [SerializeField] private Renderer[] _renderers = default;
        [Range(0f, 1f)]
        [SerializeField] private float _animationDuration = 0.2f;

        public void FadeIn()
        {
            foreach (var renderer in _renderers)
                renderer.material.DOFade(1f, _animationDuration);
        }

        public void FadeOut()
        {
            foreach (var renderer in _renderers)
                renderer.material.DOFade(0f, _animationDuration);
        }

        protected void FadeOutInstantly()
        {
            foreach (var renderer in _renderers)
                renderer.material.DOFade(0f, 0f);
        }

        private void Reset()
        {
            _renderers = GetComponentsInChildren<Renderer>();
        }
    }
}