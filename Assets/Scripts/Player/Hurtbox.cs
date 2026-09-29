using System;
using UnityEngine;
using UnityEngine.Events;

public class Hurtbox : MonoBehaviour
{
    public UnityEvent OnHit;

    public void TriggerOnHit()
    {
        Debug.Log("On hit Event");
        OnHit?.Invoke();
    }
}
