using System.Collections.ObjectModel;
using UnityEngine;

namespace IdleGame.Spawning
{
    using Entities;

    public abstract class Spawner<T, K> : MonoBehaviour where T : EntityBase<K> where K : EntityData
    {
        [SerializeField] protected K spawnableEntity;
        [SerializeField] protected Transform root = null;

        public K Data => spawnableEntity;
        public ObservableCollection<T> SpawnedObjects { get; private set; } = new ObservableCollection<T>();

        protected virtual T Spawn(Vector3 position)
        {
            var entity = Instantiate(spawnableEntity.prefab, root).GetComponent<T>();
            entity.transform.localPosition = position;

            entity.Destroyed += OnEntityDestroyed;

            SpawnedObjects.Add(entity);

            return entity;
        }

        public void RemoveAllObjects()
        {
            if (Application.isPlaying)
            {
                foreach (var obj in SpawnedObjects)
                {
                    try { Destroy(obj.gameObject); }
                    catch { }
                }
            }
            else
            {
                foreach (var child in transform.parent.GetComponentsInChildren<T>())
                    DestroyImmediate(child.gameObject);
            }

            SpawnedObjects.Clear();
        }

        private void OnEntityDestroyed(EntityBase<K> entity)
        {
            SpawnedObjects.Remove(entity as T);
        }
    }
}