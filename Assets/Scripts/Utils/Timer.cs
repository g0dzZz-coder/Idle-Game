using System;
using UnityEngine;

namespace IdleGame.Utils
{
    public class Timer
    {
        private Action _callback;

        private float _interval;
        private float _elapsedTime;

        private bool _isPaused;

        public Timer(float interval, Action callback)
        {
            _interval = interval;
            _callback = callback;
        }

        public void Update()
        {
            if (_isPaused)
                return;

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < _interval)
                return;

            _callback?.Invoke();
            Reset();
        }

        public void Pause()
        {
            _isPaused = true;
        }

        public void Unpause()
        {
            _isPaused = false;
        }

        public void Reset()
        {
            _elapsedTime = 0f;
        }
    }
}