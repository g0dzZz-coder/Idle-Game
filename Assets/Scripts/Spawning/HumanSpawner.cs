using UnityEngine;

namespace IdleGame.Spawning
{
    using Entities.People;
    using Utils;
    using Core;

    public class HumanSpawner : Spawner<Human, HumanData>
    {
        [SerializeField] private HumanSpawnZone[] _spawnZones = default;

        private IOnHumanSpawnedWatcher[] _watchers;
        private Timer _timer;

        private void Awake()
        {
            _watchers = RootProvider.Instance.Root.GetComponentsInChildren<IOnHumanSpawnedWatcher>();
        }

        private void Start()
        {
            _timer = new Timer(MainHandler.Instance.Config.spawnInterval, TryToSpawn);
            _timer.Start();
        }

        private void Update()
        {
            _timer.Update(Time.deltaTime);
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

            EmitOnHumanSpawned(human);
        }

        private void EmitOnHumanSpawned(Human human)
        {
            foreach (var watcher in _watchers)
                watcher.OnHumanSpawned(human);
        }

        public void Reset()
        {
            _spawnZones = GetComponentsInChildren<HumanSpawnZone>();
        }
    }
}