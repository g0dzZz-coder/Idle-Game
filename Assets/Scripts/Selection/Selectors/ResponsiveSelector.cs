using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IdleGame.Selection
{
    using Utils;

    public class ResponsiveSelector : MonoBehaviour, ISelector
    {
        [SerializeField] private List<Selectable> _selectables;
        [SerializeField] private float _threshold = 0.97f;

        private Transform _selection;

        public void Check(Ray ray)
        {
            _selection = null;

            var closest = 0f;

            for (int i = 0; i < _selectables.Count; i++)
            {
                var vector1 = ray.direction;
                var vector2 = _selectables[i].transform.position - ray.origin;

                var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

                _selectables[i].LookPercentage = lookPercentage;

                if (lookPercentage > _threshold && lookPercentage > closest)
                {
                    closest = lookPercentage;
                    _selection = _selectables[i].transform;
                }
            }
        }

        public Transform GetSelection()
        {
            return _selection;
        }

        public void Reset()
        {
            _selectables = RootProvider.Instance.Root.GetComponentsInChildren<Selectable>().ToList();
        }
    }
}