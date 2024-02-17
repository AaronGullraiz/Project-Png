using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimalPathFollow : MonoBehaviour
{
    public float speed, rotationSpeed;

    public UnityEvent OnTouch;

    private Transform[] waypoints;

    private int currentWayPoint = 0;

    private bool isInTouch = false;

    void Start()
    {
        waypoints = WaypointsHolder.Instance.GetWaypoints(gameObject.name);
    }

    void Update()
    {
        if (isInTouch)
        {
            return;
        }

        if (Vector3.Distance(transform.position, waypoints[currentWayPoint].position) < 0.1f)
        {
            currentWayPoint=(currentWayPoint+1)%waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPoint].position, Time.deltaTime * speed);
            transform.forward = Vector3.MoveTowards(transform.forward, waypoints[currentWayPoint].position - transform.position, Time.deltaTime * rotationSpeed);

            var rot = transform.localEulerAngles;
            rot.x = rot.z = 0;
            transform.localEulerAngles = rot;
        }
    }

    public void OnAnimalTouch()
    {
        if (!isInTouch)
        {
            isInTouch = true;
            OnTouch.Invoke();
        }
    }

    public void RestartWalk()
    {
        isInTouch = false;
    }
}