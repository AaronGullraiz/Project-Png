using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterDelay : MonoBehaviour
{
    public float delay;

    private void Start()
    {
        Invoke(nameof(DisableObject), delay);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}