using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IdleGame.UI
{
    using Utils;

    public class SceneChanger : MonoSingleton<SceneChanger>
    {
        [SerializeField] private CanvasGroup _canvasGroup = null;
        [Range(0f, 2f)]
        [SerializeField] private float _duration = 0.5f;

        private string _sceneToLoad = string.Empty;
        private string _lastScene = string.Empty;

        protected override void OnAwake()
        {
            PlayFadeInAnimation();
        }

        public void FadeToScene(string newScene)
        {
            if (newScene == SceneManager.GetActiveScene().name || string.IsNullOrWhiteSpace(newScene))
                return;

            _sceneToLoad = newScene;
            PlayFadeOutAnimation();
        }

        public void BackToPreviosScene()
        {
            _sceneToLoad = _lastScene;
            PlayFadeOutAnimation();
        }

        public void OnFadeComplete()
        {
            SceneManager.LoadSceneAsync(_sceneToLoad).completed += OnSceneLoaded;
        }

        private void PlayFadeInAnimation()
        {
            if (_canvasGroup == null)
                return;

            _canvasGroup.alpha = 1f;
            _canvasGroup.DOFade(0f, _duration);
        }

        private void PlayFadeOutAnimation()
        {
            if (_canvasGroup == null)
                return;

            _canvasGroup.DOFade(1f, _duration).OnComplete(() => OnFadeComplete());
        }

        private void OnSceneLoaded(AsyncOperation operation)
        {
            _lastScene = _sceneToLoad;
            PlayFadeInAnimation();
        }

        private void OnValidate()
        {
            if (_canvasGroup == null)
                Debug.LogError($"[{nameof(SceneChanger)}] {nameof(CanvasGroup)} is empty!");
        }
    }
}
