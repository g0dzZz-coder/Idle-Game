using UnityEngine;

namespace IdleGame.Levels
{
    using Utils;

    public class LevelLogic : MonoSingleton<LevelLogic>
    {
        [SerializeField] private LevelData _data = default;

        public LevelData Data => _data;
    }
}