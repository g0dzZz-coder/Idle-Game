using UnityEngine;

namespace IdleGame.Selection
{
    public interface ISelector
    {
        void Check(Ray ray);
        Transform GetSelection();
    }
}