using System;
using UnityEngine;

namespace IdleGame.Utils
{
    public class Timer
    {
        private Action _callback;

        private float _interval;
        private float _elapsedTime;

        private bool _isActive;

        public Timer(float interval, Action callback)
        {
            _interval = interval;
            _callback = callback;
        }

        public void Update()
        {
            if (_isActive == false)
                return;

            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < _interval)
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
            _elapsedTime = 0f;
        }
    }
}