using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelect : MonoBehaviour
{
    public GameObject raycastObject;
    Vector3 fwd;
    LineRenderer line;

    private void Start()
    {
        fwd = raycastObject.transform.TransformDirection(Vector3.back);
    }

    public void CastRay()
    {
        Debug.Log("here");
        RaycastHit objectHit;

        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = true;
        line.positionCount = 2;
       

        if (Physics.Raycast(raycastObject.transform.position, fwd, out objectHit, 50))
        {
            Debug.Log("hit");
        }
    }

    private void Update()
    {
        Debug.DrawRay(raycastObject.transform.position, fwd * 500, Color.green);
        line.SetPosition(0, raycastObject.transform.position);
        line.SetPosition(0, fwd);
    }
}
