using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CellPlacement : MonoBehaviour
{

    public List<CellMovement> cM;
    public int nbrTouch;
    public GameObject FirstTouched;
    public GameObject SecondTouched;
    public Vector3 direction;

    public Camera fingerCamera;
    public CinemachineBrain myBrain;


    // Use this for initialization
    void Start()
    {

        nbrTouch = 0;

    }

    // Update is called once per frame
    void Update()
    {

        //CheckForDirection();


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(myBrain.OutputCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.gameObject.GetComponent<CellMovement>() != null)
                {
                    Debug.Log("ok so I work");
                    hit.collider.gameObject.GetComponent<CellMovement>().click = true;
                    hit.collider.gameObject.GetComponent<CellMovement>().over = true;

                    hit.collider.gameObject.GetComponent<CellMovement>().originPos = Input.mousePosition;

                }
            }
            else
            {
                for (int i = 0; i < cM.Count; i++)
                {

                    cM[i].over = false;

                }
            }
        }


    }


    public void CheckForDirection()
    {
       
        if (Input.GetMouseButton(0))
        {



            for (int i = 0; i < cM.Count; i++)
            {

                if (cM[i].selected == true && cM[i] != FirstTouched)
                {
                    if (FirstTouched == null)
                    {

                        FirstTouched = cM[i].gameObject;
                        cM[i].selected = false;
                        cM[i].over = false;
                    }
                    else if(FirstTouched != null && cM[i] != FirstTouched)
                    {
                        SecondTouched = cM[i].gameObject;
                        cM[i].selected = false;
                        cM[i].over = false;


                    }

                    nbrTouch += 1;

                }

            }
           


        }
        if (nbrTouch > 2 || Input.GetMouseButtonUp(0))
        {
            if (SecondTouched != null)
            {
                direction = SecondTouched.transform.position - FirstTouched.transform.position;
               // Debug.Log(direction);
                FirstTouched = null;
                SecondTouched = null;
            }
            nbrTouch = 0;

        }

    }
}
