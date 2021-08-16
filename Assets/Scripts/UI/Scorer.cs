using TMPro;
using UnityEngine;
using DG.Tweening;

namespace IdleGame.UI
{
    using Core;
    using Player;

    public class Scorer : UIElement
    {
        [SerializeField] private Vector2 _scaleStrength = new Vector2(0.5f, 0.5f);
        [SerializeField] private TMP_Text _scoreText = default;

        private Vector3 _initialScale;

        private void Start()
        {
            _initialScale = _scoreText.transform.localScale;

            GameLogic.Instance.Started += OnGameStarted;
            GameLogic.Instance.Ended += OnGameEnded;
            Player.ScoreChanged += UpdateScore;

            Root.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _scoreText.transform.DOKill();

            //GameLogic.Instance.Started -= OnGameStarted;
            //GameLogic.Instance.Ended -= OnGameEnded;
            Player.ScoreChanged -= UpdateScore;
        }

        public void UpdateScore(int value)
        {
            _scoreText.text = value.ToString();

            _scoreText.transform.localScale = _initialScale;
            _scoreText.transform.DOKill();
            _scoreText.transform.DOPunchScale(_scaleStrength, _animationDuration, 0);
        }

        private void OnGameStarted()
        {
            UpdateScore(0);
            Show();
        }

        private void OnGameEnded()
        {
            Hide();
        }
    }
}