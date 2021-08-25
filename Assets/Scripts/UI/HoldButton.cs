using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

namespace IdleGame.UI
{
    using Utils;
    using Selectable = UnityEngine.UI.Selectable;

    public class HoldButton : Selectable
    {
        [Range(0f, 5f)]
        [SerializeField] private float _holdTime = 1f;
        [SerializeField] private Image _fillingImage = default;
        public UnityEvent onHold = new UnityEvent();

        private Timer _timer;
        private bool _isEnabled;
        private bool _isHolding;

        protected override void Awake()
        {
            base.Awake();

            _timer = new Timer(_holdTime, DoActions);
        }

        private void Update()
        {
            if (_isHolding == false)
                return;

            _timer.Update(Time.deltaTime);
            UpdateFilling(_timer.elapsedTime);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            if (_isEnabled == false)
                return;

            _isHolding = true;
            _timer.Start();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            _isHolding = false;
            _timer.Stop();
            UpdateFilling(0f);
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }

        private void UpdateFilling(float elapsedTime)
        {
            if (_fillingImage == null)
                return;

            var amount = elapsedTime / _holdTime;
            _fillingImage.fillAmount = amount;
        }

        private void DoActions()
        {
            _timer.Stop();
            onHold?.Invoke();
        }
    }
}