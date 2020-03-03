using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public int maxVelocity = 0;
    public float patrolA = 19.5f;
    public float patrolB = -19.5f;
    private int direction = 0;

    void Start()
    {
        transform.position = new Vector3(20, 0.5f, 0);
    }

    void Update()
    {
        switch(direction)
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
}
