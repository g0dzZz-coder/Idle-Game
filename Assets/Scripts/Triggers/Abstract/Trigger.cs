using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    protected Collider Collider
    {
        get
        {
            if (_collider == null)
            {
                _collider = GetComponent<Collider>();
                _collider.isTrigger = true;
            }

            return _collider;
        }
    }

    public event Action<Collider> TriggerEntered;

    private Collider _collider;

    private void Awake()
    {
        Collider.isTrigger = true;
    }

    protected void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered(other);
        TriggerEntered?.Invoke(other);
    }

    protected virtual void OnTriggerEntered(Collider collider) { }

    public void Enable()
    {
        Collider.enabled = true;        
    }

    public void Disable()
    {
        Collider.enabled = false;
    }
}
