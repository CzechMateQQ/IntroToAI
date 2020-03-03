using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Patrol,
    Seek,
    Flee
}

public class StateMachine : MonoBehaviour
{
    // General variables
    public int maxVelocity = 0;
    public GameObject target;
    private States currentState;

    // Patrol variables
    public float patrolA = 19.5f;
    public float patrolB = -19.5f;
    private int direction = 0;
    Vector3 startPosition = new Vector3(20, 0.5f, 0);

    // Seek & Flee variables
    public Transform tmpTarget;
    Vector3 v;
    Vector3 currentVelocity;
    Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case States.Patrol:
                Patrol();
                break;
            case States.Seek:
                Seek();
                break;
            case States.Flee:
                Flee();
                break;
            default:
                Debug.LogError("Invalid State");
                break;
        }
    }

    void Patrol()
    {
        while(transform.position.x != startPosition.x)
        {
            v = ((startPosition - transform.position).normalized) * maxVelocity;
            force = v - currentVelocity;
            currentVelocity += force * Time.deltaTime;
            transform.position += currentVelocity * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(currentVelocity);
        }

        switch (direction)
        {
            case 0:
                transform.position += new Vector3(0, 0, maxVelocity * Time.deltaTime);
                break;
            case 1:
                transform.position -= new Vector3(0, 0, maxVelocity * Time.deltaTime);
                break;
        }

        if (transform.position.z >= patrolA)
            direction = 1;

        if (transform.position.z <= patrolB)
            direction = 0;
    }

    void Seek()
    {
        v = ((tmpTarget.position - transform.position).normalized) * maxVelocity;
        force = v - currentVelocity;
        currentVelocity += force * Time.deltaTime;
        transform.position += currentVelocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(currentVelocity);
    }

    void Flee()
    {
        v = ((transform.position - tmpTarget.position).normalized) * maxVelocity;
        force = v - currentVelocity;
        currentVelocity += force * Time.deltaTime;
        transform.position += currentVelocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(currentVelocity);
    }

    void ChangeState(States newState)
    {

    }

    void OnPatrolEnter()
    {

    }

    void OnPatrolExit()
    {

    }

    void OnSeekEnter()
    {

    }
    void OnSeekExit()
    {

    }

    void OnFleeEnter()
    {

    }

    void OnFleeExit()
    {

    }
}
