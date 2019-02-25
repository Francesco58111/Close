using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityKiller : MonoBehaviour
{
    public Material myMaterial;
    public GameObject cam;
    public float distance;
    private float opaciteVar;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {


        distance = Vector3.Distance(transform.position, cam.transform.position);

        myMaterial.SetFloat("_Opacity", opaciteVar);


        if (distance < 2.5f)
        {
            if(opaciteVar > (-1.7f + distance) / 2)
            {
                opaciteVar -= 0.01f;
            }
            else
            {
                opaciteVar = (-1.7f + distance) / 2;
            }
        }
        else
        {
            if(opaciteVar < 1)
            {
                opaciteVar += 0.01f;
            }
            else
            {
                opaciteVar = 1;
            }

        }


        //Debug.Log(distance);
    }
}
