using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingandReleasingObjects : MonoBehaviour
{
    // identifying objects
    GameObject CollidingObject;
    public GameObject objectInHand = null;

    public bool objectGrabbed = false;
    public bool objectReleased = false;

    //when the controllers collide with the grabbable object
    //picking up objects with rigidbodies
    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.GetComponent<Rigidbody>() && other.gameObject.tag == "grabbable")
        {
            CollidingObject = other.gameObject;    
        }
    }

    // releasing those objects with rigidbodies
    public void OnTriggerExit(Collider other) 
    {
        CollidingObject = null;
    }

    //create parentchild relationship between object and hand so object follows hand
    public void GrabObject() 
    {
        objectGrabbed = true;
        objectReleased = false;
        objectInHand = CollidingObject;
        objectInHand.transform.SetParent(this.transform);
        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
    }

    //removing parentchild relationship so you drop the object
    public void ReleaseObject()
    {
        objectReleased = true;
        objectGrabbed = false;
        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.transform.SetParent(null);
        objectInHand = null;
    }

}

