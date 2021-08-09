using System;
using System.Collections;
using UnityEngine;

public static class MonoBehaviorExtensions
{
    /// <summary>
    /// Invoke at Coroutine
    /// </summary>
    /// <param name="time">in seconds</param>
    /// <param name="endAction"> Action </param>
    public static void InvokeAtTime(this MonoBehaviour target, float time, Action endAction)
    {
        target.StartCoroutine(WaitPlugin(time, endAction));
    }

    private static IEnumerator WaitPlugin(float time, Action endAction)
    {
        yield return new WaitForSeconds(time);
        endAction?.Invoke();
    }
}
