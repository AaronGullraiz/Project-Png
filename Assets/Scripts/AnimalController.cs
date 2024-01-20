using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AnimalController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private UnityEvent OnTouchEvent;

    private int waypointIndex = 0;

    private bool isTouched;

    void Start()
    {
        waypoints = WaypointsHolder.Instance.GetWaypoints(gameObject.name);

        agent.SetDestination(waypoints[waypointIndex].position);
        anim.SetBool("Walk", true);
    }

    private void Update()
    {
        if (!agent.isStopped && waypoints.Length>0)
        {
            if (agent.remainingDistance < 0.5f)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                agent.SetDestination(waypoints[waypointIndex].position);
            }
        }
    }

    private Vector3 velocity;

    public void OnAnimalTouched()
    {
        if (!isTouched)
        {
            isTouched = true;
            agent.isStopped = true;
            velocity = agent.velocity;
            agent.velocity = Vector3.zero;
            anim.SetTrigger("Touch1");

            OnTouchEvent.Invoke();
        }
    }

    public void RestartWalk()
    {
        isTouched = false;
        agent.isStopped = false;
        agent.velocity = velocity;
    }

    public void SetWalkSpeed(int speed)
    {
        agent.speed = speed;
        agent.angularSpeed = Mathf.Clamp(speed * speed,5,100);
        anim.speed = 0.7f+(speed * 0.3f);
    }
}