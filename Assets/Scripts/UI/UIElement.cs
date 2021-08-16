using DG.Tweening;
using System;
using UnityEngine;

namespace IdleGame.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIElement : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField] protected float _animationDuration = 0.2f;

        protected CanvasGroup Root
        {
            get
            {
                if (_canvasGroup == null)
                    _canvasGroup = GetComponent<CanvasGroup>();

                return _canvasGroup;
            }
        }
        private CanvasGroup _canvasGroup;

        public void Show() => Show(() => { });

        public void Hide() => Hide(() => { });

        protected void Show(Action onComplete = null)
        {
            Root.alpha = 0f;
            Root.gameObject.SetActive(true);

            Root.DOKill();
            Root.DOFade(1f, _animationDuration).OnComplete(() =>
            {
                onComplete?.Invoke();
            });
        }

        protected void Hide(Action onComplete = null)
        {
            Root.DOKill();
            Root.DOFade(0f, _animationDuration).OnComplete(() =>
            {
                Root.gameObject.SetActive(false);
                onComplete?.Invoke();
            });
        }
    }
}