using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    RaycastHit hit;

    public void CastRay()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.CompareTag("Hand"))
            {
                GameObject.Find("HandMenu").SetActive(true);
            }
            else
            {
                GameObject.Find("HandMenu").SetActive(false);
            }
        }
    }

    private void Update()
    {
        CastRay();
    }
}
