using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceGrab : MonoBehaviour
{
    GameObject hitGameObject;
    GameObject lastHitGameObject;

    bool pressed = false;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.transform.tag == "DistanceGrab")
            {
                hitGameObject = hit.transform.gameObject;
                hitGameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
        }
        else
        {
            hitGameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            hitGameObject.GetComponent<Rigidbody>().isKinematic = false;
            hitGameObject = null;
        }

        if(pressed)
        {
            hitGameObject.transform.position = Vector3.MoveTowards(hitGameObject.transform.position, this.transform.position, 1.0f * Time.deltaTime);
            hitGameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void ButtonPress()
    {
        pressed = true;
    }

    public void ButtonRelease()
    {
        hitGameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        hitGameObject.GetComponent<Rigidbody>().isKinematic = false;
        pressed = false;
    }

}
