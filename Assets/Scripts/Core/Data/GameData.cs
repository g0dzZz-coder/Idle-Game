using UnityEngine;

namespace IdleGame.Data
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Core/Config", order = 51)]
    public class GameData : ScriptableObject
    {
        public int targetFrameRate = 60;
    }
}