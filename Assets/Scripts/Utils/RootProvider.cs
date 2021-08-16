using UnityEngine;

namespace IdleGame.Utils
{
    public class RootProvider : MonoSingleton<RootProvider>
    {
        public Transform Root => transform;
    }
}