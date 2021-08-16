namespace IdleGame.Spawning
{
    using Entities.People;

    public interface IOnHumanSpawnedWatcher
    {
        void OnHumanSpawned(Human human);
    }
}