using System;
using UnityEngine;

namespace IdleGame.Utils
{
    public class Timer
    {
        public float elapsedTime;

        private Action _callback;

        private float _interval;
        private bool _isActive;

        public Timer(float interval, Action callback)
        {
            _interval = interval;
            _callback = callback;
        }

        public void Update(float delta)
        {
            if (_isActive == false)
                return;

            elapsedTime += delta;
            if (elapsedTime < _interval)
                return;

            _callback?.Invoke();
            Reset();
        }

        public void Start()
        {
            Reset();
            Unpause();
        }

        public void Stop()
        {
            Pause();
            Reset();
        }

        public void Pause()
        {
            _isActive = false;
        }

        public void Unpause()
        {
            _isActive = true;
        }

        public void Reset()
        {
            elapsedTime = 0f;
        }
    }
}