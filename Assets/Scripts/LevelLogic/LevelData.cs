using UnityEngine;

namespace IdleGame.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "Core/Level", order = 51)]
    public class LevelData : ScriptableObject
    {
        [Range(0, 30)]
        public int maxumimHumans = 6;


    }
}