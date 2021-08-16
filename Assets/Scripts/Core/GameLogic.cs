using System;
using UnityEngine;

namespace IdleGame.Core
{
    using Entities.People;
    using Spawning;
    using Utils;

    public class GameLogic : MonoSingleton<GameLogic>, IOnHumanSpawnedWatcher, IOnHumanDestinationReachedWatcher
    {
        public event Action Started;
        public event Action Ended;

        protected override void OnStart()
        {
            Application.targetFrameRate = MainHandler.Instance.Config.targetFrameRate;

            StartGame();
        }

        public void StartGame()
        {
            Started?.Invoke();
        }

        public void OnHumanSpawned(Human human)
        {
            human.SetMissionTarget(LevelLogic.Instance.GetRandomBuilding().transform.position);
        }

        public void OnHumanDestinationReached(Human human)
        {
            if (human.IsMissionCompleted)
            {
                Destroy(human.gameObject);
                return;
            }

            human.CompleteMission();
        }
    }
}