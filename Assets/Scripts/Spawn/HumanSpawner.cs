using UnityEngine;

namespace IdleGame.Spawn
{
    using Entities.Human;
    using Utils;
    using Core;

    public class HumanSpawner : Spawner<Human, HumanData>
    {
        [SerializeField] private HumanSpawnZone[] _spawnZones = default;
        [SerializeField] private float _interval = 3f;

        private Timer _timer;

        private void Start()
        {
            _timer = new Timer(_interval, TryToSpawn);
        }

        private void Update()
        {
            _timer.Update();
        }

        private void TryToSpawn()
        {
            if (SpawnedObjects.Count >= LevelLogic.Instance.Data.maxumimHumans)
            {
                _timer.Reset();
                return;
            }

            var randomPosition = _spawnZones.Random().GetRandomPosition();
            var human = Spawn(randomPosition);

            GameLogic.Instance.OnHumanSpawned(human);
        }
    }
}