using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navaScript_Medium : MonoBehaviour
{

    public Transform target;
    Vector3 storeTarget;
    Vector3 newTargetPosition;
    bool savePos;
    bool overrideTarget;


    Vector3 acceleration;
    Vector3 velocity;
    public float maxspeed = 1f;
    public float wingspan = 1f;
    float storeMaxSpeed;
    float targetSpeed;

    public static int hp = 80;

    Rigidbody rigidBody;
    Transform obstacle;

    public List<Vector3> EscapeDirections = new List<Vector3>();

    public Vector3 center;
    public Vector3 size;


    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    void Start()
    {

        center = transform.position;
        storeMaxSpeed = maxspeed;
        targetSpeed = storeMaxSpeed;
        rigidBody = GetComponent<Rigidbody>();



    }


    private void FixedUpdate()
    {

        //Debug.DrawLine(transform.position, target.position);
        Vector3 forces = MoveTowardsTarget(target.position);
        acceleration = forces;
        velocity += 2 * acceleration * Time.deltaTime;

        if (velocity.magnitude > maxspeed)
        {
            velocity = velocity.normalized * maxspeed;

        }

        rigidBody.velocity = velocity;

        Quaternion desiredRotation = Quaternion.LookRotation(velocity);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * 3);

        ObstacleAvoidance(transform.forward, 0);

        if (overrideTarget)
        {
            target.position = newTargetPosition;
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "target")
        {
            target.position = center + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-7, 7));
            EscapeDirections.Clear();

        }
    }

    Vector3 MoveTowardsTarget(Vector3 target1)
    {
        Vector3 distance = target1 - transform.position;

        if (distance.magnitude < 0.5)
        {

            return distance.normalized * -maxspeed;

        }
        else
        {
            return distance.normalized * maxspeed;
        }


    }


    void ObstacleAvoidance(Vector3 direction, float offsetX)
    {
        RaycastHit[] hit = Rays(direction, offsetX);

        for (int i = 0; i < hit.Length - 1; i++)
        {
            if (hit[i].transform.root.gameObject != this.gameObject)
            {
                if (!savePos)
                {
                    storeTarget = target.position;
                    obstacle = hit[i].transform;
                    savePos = true;
                }

                FindEscapeDirections(hit[i].collider);
            }
        }

        if (EscapeDirections.Count > 0)
        {
            if (!overrideTarget)
            {
                newTargetPosition = getClosests();
                overrideTarget = true;
            }
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < 5)
        {
            if (savePos)
            {
                target.position = storeTarget;
                savePos = false;
            }

            overrideTarget = false;
            EscapeDirections.Clear();
        }
    }


    Vector3 getClosests()
    {
        Vector3 clos = EscapeDirections[0];
        float distance = Vector3.Distance(transform.position, EscapeDirections[0]);

        foreach (Vector3 dir in EscapeDirections)
        {
            float tempDistance = Vector3.Distance(transform.position, dir);

            if (tempDistance < distance)
            {
                distance = tempDistance;
                clos = dir;
            }
        }
        return clos;
    }

    void FindEscapeDirections(Collider col)
    {
        RaycastHit hitUp;

        if (Physics.Raycast(col.transform.position, col.transform.up, out hitUp, col.bounds.extents.y * 2 * wingspan))
        {

        }
        else
        {
            Vector3 dir = col.transform.position + new Vector3(0, col.bounds.extents.y * 2 + wingspan, 0);

            if (!EscapeDirections.Contains(dir))
            {
                EscapeDirections.Add(dir);
            }
        }




        RaycastHit hitDown;

        if (Physics.Raycast(col.transform.position, -col.transform.up, out hitDown, col.bounds.extents.y * 2 * wingspan))
        {

        }
        else
        {
            Vector3 dir = col.transform.position + new Vector3(0, -col.bounds.extents.y * 2 + wingspan, 0);

            if (!EscapeDirections.Contains(dir))
            {
                EscapeDirections.Add(dir);
            }
        }



        RaycastHit hitRight;

        if (Physics.Raycast(col.transform.position, col.transform.right, out hitRight, col.bounds.extents.x * 2 * wingspan))
        {

        }
        else
        {
            Vector3 dir = col.transform.position + new Vector3(col.bounds.extents.x * 2 - wingspan, 0, 0);

            if (!EscapeDirections.Contains(dir))
            {
                EscapeDirections.Add(dir);
            }
        }



        RaycastHit hitLeft;

        if (Physics.Raycast(col.transform.position, -col.transform.right, out hitLeft, col.bounds.extents.x * 2 * wingspan))
        {

        }
        else
        {
            Vector3 dir = col.transform.position + new Vector3(-col.bounds.extents.x * 2 - wingspan, 0, 0);

            if (!EscapeDirections.Contains(dir))
            {
                EscapeDirections.Add(dir);
            }
        }
    }

    RaycastHit[] Rays(Vector3 direction, float offsetX)
    {
        Ray ray = new Ray(transform.position + new Vector3(offsetX, 0, 0), direction);
        Debug.DrawRay(transform.position + new Vector3(offsetX, 0, 0), direction * 10 * maxspeed);

        float distanceToLookAhead = maxspeed * 10;
        RaycastHit[] hits = Physics.SphereCastAll(ray, 5, distanceToLookAhead);

        return hits;
    }

}
