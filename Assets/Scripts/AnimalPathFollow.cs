using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimalPathFollow : MonoBehaviour
{
    public float speed, rotationSpeed;
    [Range(1,10)]
    public int touchAnimationsCount = 1;

    public UnityEvent OnTouch;

    [SerializeField]
    protected Transform[] waypoints;

    protected int currentWayPoint = 0;

    private bool isInTouch = false;

    private int touchAnim = 1;

    [SerializeField]
    private Animator anim;

    void Start()
    {
        waypoints = WaypointsHolder.Instance.GetWaypoints(gameObject.name);
    }

    void LateUpdate()
    {
        if (isInTouch)
        {
            return;
        }

        if (Vector3.Distance(transform.position, waypoints[currentWayPoint].position) < 0.1f)
        {
            ReachedWaypoint(waypoints[currentWayPoint]);
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPoint].position, Time.deltaTime * speed);
        transform.forward = Vector3.MoveTowards(transform.forward, waypoints[currentWayPoint].position - transform.position, Time.deltaTime * rotationSpeed);

        var rot = transform.localEulerAngles;
        rot.x = rot.z = 0;
        transform.localEulerAngles = rot;
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

    public void PlayTouchAnimation(string animName)
    {
        anim.Play(animName + touchAnim);
        touchAnim = ((touchAnim + 1) % touchAnimationsCount);
    }

    protected virtual void ReachedWaypoint(Transform waypoint)
    {
        currentWayPoint = (currentWayPoint + 1) % waypoints.Length;
    }
}