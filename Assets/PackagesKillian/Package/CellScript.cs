﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour {


    public bool first;
    public int timer;
    public int nbrTouch;
    public bool rotation;
    public bool set;
    public Quaternion myRot;
    public int timeRot = 0;
    public int fin;
    public Quaternion wtf;

	void Start () {

        first = false;

	}
	
	void Update () {

        wtf =  myRot * new Quaternion(0, 90, 0, 0);

        if (first)
        {
            timer++;

            if(timer>= 30)
            {
                nbrTouch = 0;
                timer = 0;
                first = false;
            }
        }

        if(rotation)
        {
            transform.Rotate(new Vector3 (0,90,0), 1.2f);
            
            timeRot++;

            if (/*transform.rotation == myRot*new Quaternion(0,90,0,0) */timeRot > fin)
            {
                timeRot = 0;
                rotation = false;
            }
        }
      
	}

    public void OnMouseDown()
    {
        first = true;
        nbrTouch += 1;

        if (first && nbrTouch>1)
        {
            set = true;
            if (set)
            {
                myRot = transform.rotation;
                set = false;
            }
            rotation = true;
            nbrTouch = 0;
            
        }

    }
    /*public void OnMouseUp()
    {
        nbrTouch += 1;

    }*/

}
