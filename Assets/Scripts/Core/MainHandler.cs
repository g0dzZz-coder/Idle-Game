using UnityEngine;
using UnityEngine.Assertions;

namespace IdleGame.Core
{
    using Data;
    using Utils;

    public class MainHandler : MonoSingleton<MainHandler>
    {
        [SerializeField] private GameData _config;

        public GameData Config => _config;

        protected override void OnStart()
        {
            Assert.IsNotNull(_config);
        }
    }
}