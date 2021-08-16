using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleGame.Core
{
    using IdleGame.Entities.Buildings;
    using IdleGame.Entities.Human;
    using Utils;

    public class GameLogic : MonoSingleton<GameLogic>
    {
        public void OnHumanSpawned(Human human)
        {
            human.Movement.SetTarget(LevelLogic.Instance.GetRandomBuilding().transform.position);
        }

        public void OnHumanInteractionWithBuildingStarted(Human human, Building building)
        {
            human.Movement.ReturnToStartPoint();
        }
    }
}