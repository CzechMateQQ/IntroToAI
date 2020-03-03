using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    // The object that this agent is seeking out
    public GameObject target;
    public Transform tmpTarget;
    Vector3 v;
    Vector3 currentVelocity;
    public float maxVelocity;
    public int fleeBuffer;
    Vector3 force;
    // The speed that the agent will move at (given in units per second)

    void Update()
    {
        // TODO for Students
        // Update the position of this agent such that it is closer to its target
        // let tmpTarget be a reference to the Transform of an enemy
        if((transform.position - tmpTarget.position).magnitude < fleeBuffer)
        {
            v = ((transform.position - tmpTarget.position).normalized) * maxVelocity;
            force = v - currentVelocity;
            currentVelocity += force * Time.deltaTime;
            transform.position += currentVelocity * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(currentVelocity);
        }
    }
}
