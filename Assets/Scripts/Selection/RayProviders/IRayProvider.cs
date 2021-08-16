using UnityEngine;

namespace IdleGame.Selection
{
    public interface IRayProvider
    {
        Ray CreateRay();
    }
}