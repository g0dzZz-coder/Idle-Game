using UnityEngine;

namespace IdleGame.Core
{
    using Data;
    using Entities.Buildings;
    using Utils;

    public class LevelLogic : MonoSingleton<LevelLogic>
    {
        [SerializeField] private LevelData _data = default;
        [SerializeField] private Building[] _buildings = default;

        public LevelData Data => _data;

        public Building GetRandomBuilding()
        {
            return _buildings.Random();
        }
    }
}