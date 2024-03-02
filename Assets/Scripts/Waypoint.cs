using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Waypoint : MonoBehaviour
{
    public string animationName;

    public bool isTouchEnd;

    public float speed;

    public UnityEvent eventOnReach;
}