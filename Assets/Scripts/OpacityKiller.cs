using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityKiller : MonoBehaviour
{
    public Material myMaterial;
    public GameObject cam;
    public float distance;
    private float opaciteVar;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        if(gameObject.name.Contains("Up") == false && gameObject.name.Contains("Down") == false && isActive)
        {
            opaciteVar = 1;
        }


        distance = Vector3.Distance(transform.position, cam.transform.position);

        myMaterial.SetFloat("_Opacity", opaciteVar);

        if (!isActive)
        {
            if (distance < 2.5f)
            {
                if (opaciteVar > (-1.9f + distance) / 2)
                {
                    opaciteVar -= 0.01f;
                }
                else
                {
                    opaciteVar = (-1.9f + distance) / 2;
                }
            }
            else
            {
                if (opaciteVar < 1)
                {
                    opaciteVar += 0.01f;
                }
                else
                {
                    opaciteVar = 1;
                }

            }
        }

        //Debug.Log(distance);
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.name == "OpacityToZero")
        {
            isActive = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "OpacityToZero")
        {
            isActive = false;
        }
    }
}
