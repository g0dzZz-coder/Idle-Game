using DG.Tweening;
using System;
using UnityEngine;

namespace IdleGame.Entities
{
    public abstract class EntityViewBase : MonoBehaviour
    {
        [SerializeField] private Renderer[] _renderers = default;
        [Range(0f, 1f)]
        [SerializeField] private float _animationDuration = 0.2f;

        public void OnDestroying(Action onComplete = null)
        {
            FadeOut(onComplete);
        }

        public void FadeIn()
        {
            foreach (var renderer in _renderers)
                renderer.material.DOFade(1f, _animationDuration);
        }

        public void FadeOut(Action onComplete = null)
        {
            foreach (var renderer in _renderers)
                renderer.material.DOFade(0f, _animationDuration).OnComplete(() => onComplete?.Invoke());
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