using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool reset;
    public bool movement;
    public Vector3 origin;
    public bool once;
    public Lister waypoints;
    public ScrEnvironment context;
    public float distance;
    public float minDist = 0.1f;
    public Vector3 direction;

    public int myPath;
    public bool one;
    public bool zero;
    public List<bool> ways;

    public int index;
    public bool next = true;

    void Start()
    {
        minDist = 0.1f;
    }

    void Update()
    {
        /*
        if(ways.Count < context.paths.list.Count)
        {
            ways.Add(new bool());
        }
        if(ways.Count > context.paths.list.Count)
        {
            ways.RemoveAt(ways.Count - 1);
        }
        */
       /* = context.paths.list;*/

        if (reset)
        {
            ResetWhenTooFar();
        }

        if(zero)
        {
            myPath = 0;
            zero = false;
            GetPath(myPath);

        }

        if (one)
        {
            myPath = 1;
            one = false;
            GetPath(myPath);

        }

        //waypoints = context.paths.list[0];




        if (movement)
        {
            if (waypoints.listOfWaypoint.Count != 0)
            {
                CalculateDistance(waypoints.listOfWaypoint[index].position);
                //direction = waypoints[0].position;
                if (!once)
                {
                    origin = transform.position;
                    once = true;
                }
                
                transform.position = Vector3.Lerp(transform.position, waypoints.listOfWaypoint[index].position, 0.05f);

                if (distance <= minDist && index != waypoints.listOfWaypoint.Count-1 && next)
                {
                    //once = false;
                    //movement = false;
                    //reset = true;
                    index++;
                    next = false;
                }
                else if (distance <= minDist && index == waypoints.listOfWaypoint.Count - 1)
                {
                    index = 0;
                    movement = false;
                    
                }
            }
        }


    }



    public void GetPath(int path)
    {
        if(path < context.paths.list.Count)
        {
            waypoints = context.paths.list[path];
        }
        myPath = 4;
        movement = true;
    }

    private void ResetWhenTooFar()
    {
        if (Vector3.Distance(transform.position, context.basePos.position) >= 0.1f && !movement)
        {
            transform.position = Vector3.Lerp(transform.position, context.basePos.position, 0.05f);
        }
        else
        {
            reset = false;

        }
    }

    public void CalculateDistance(Vector3 objectif)
    {

        distance = Vector3.Distance(transform.position, objectif);
        if(distance > minDist)
        {
            next = true;
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<ScrEnvironment>() != null)
        {

            context = other.GetComponent<ScrEnvironment>();

        }
    }
}
