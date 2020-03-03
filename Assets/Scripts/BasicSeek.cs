using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSeek : MonoBehaviour
{
    // The object that this agent is seeking out
    public GameObject target;
    public Transform tmpTarget;
    Vector3 v;
    Vector3 currentVelocity;
    Vector3 force;
    public float maxVelocity;
    // The speed that the agent will move at (given in units per second)

    void Update()
    {
        // TODO for Students
        // Update the position of this agent such that it is closer to its target
        // let tmpTarget be a reference to the Transform of an enemy
        v = ((tmpTarget.position - transform.position).normalized) * maxVelocity;
        force = v - currentVelocity;
        currentVelocity += force * Time.deltaTime;
        transform.position += currentVelocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(currentVelocity);
    }
}
