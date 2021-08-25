using System;
using UnityEngine;

namespace IdleGame.Entities.Buildings
{
    [CreateAssetMenu(fileName = "Building", menuName = "Entities/Building", order = 51)]
    public class BuildingData : EntityData
    {
        public LevelSettings levels = new LevelSettings();

        [Serializable]
        public class LevelSettings
        {
            [Min(1)]
            public int initialLevel = 0;
            [Min(1)]
            public int initialReward = 1;
            [Min(0)]
            public int upgradeCost = 5;
            [Min(0)]
            public int gainPerLevel = 2;
        }
    }
}