using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell_Renamer : MonoBehaviour
{

    public string PositionName;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cell" && other.gameObject.name.Contains(PositionName) == false)
        {
            other.gameObject.name = PositionName;
            for (int i = 0; i < other.transform.childCount; i++)
            {
                //Debug.LogError(other.transform.GetChild(i).name + other.transform.GetChild(i).transform.localPosition);

                if (other.transform.GetChild(i).transform.localPosition.y == 0.5f )
                {
                    other.transform.GetChild(i).name = "PlaneUp";
                }
                else if (other.transform.GetChild(i).transform.localPosition.y == -0.5f )
                {
                    other.transform.GetChild(i).name = "PlaneDown";
                }
                else if (other.transform.GetChild(i).transform.localPosition.x == 0.5f)
                {
                    other.transform.GetChild(i).name = "PlaneForward";
                }
                else if (other.transform.GetChild(i).transform.localPosition.x == -0.5f)
                {
                    other.transform.GetChild(i).name = "PlaneAway";
                }
                else if (other.transform.GetChild(i).transform.localPosition.z == 0.5f)
                {
                    other.transform.GetChild(i).name = "PlaneRight";
                }
                else if (other.transform.GetChild(i).transform.localPosition.z == -0.5f)
                {
                    other.transform.GetChild(i).name = "PlaneLeft";
                }

            }
        }
    }
}
