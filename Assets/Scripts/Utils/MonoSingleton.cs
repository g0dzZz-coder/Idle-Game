using UnityEngine;
using UnityEngine.SceneManagement;

namespace IdleGame.Utils
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                return FindObjectOfType<T>();
            }
        }

        private static T _instance;
        private int _instancesInScene;

        protected void Awake()
        {
            _instancesInScene++;

            if (Init(Instance))
                _instance = (T)this;

            OnAwake();
        }

        protected void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            OnStart();
        }

        protected void OnDestroy()
        {
            var numComponents = GetComponentsInChildren<Component>().Length;

            if (transform.childCount == 0 && numComponents <= 2)
                Destroy(gameObject);

            _instancesInScene--;

            SceneManager.sceneLoaded -= OnSceneLoaded;

            if (Instance == this)
                _instance = null;

            OnDestroyed();
        }

        protected virtual void OnAwake() { }

        protected virtual void OnStart() { }

        protected virtual void OnDestroyed() { }

        protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (_instancesInScene < 2)
            {
                DisposeInternal();
            }
            else
            {
                if (Instance != this)
                    DisposeInternal();
            }
        }

        protected virtual bool Init(T instance)
        {
            if (instance != null && instance != this)
            {
                DisposeInternal();
                return false;
            }

            return true;
        }

        protected virtual void DisposeInternal()
        {
            Destroy(this);
        }
    }
}
