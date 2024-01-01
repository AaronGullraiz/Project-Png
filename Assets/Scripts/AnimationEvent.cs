using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public ButterflyInteractionHandler butterfly;

    public void OnButterflyOutComplete()
    {
        butterfly.OnButterflyOutComplete();
    }
}