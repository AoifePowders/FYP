using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GrabbingandReleasingObjects : MonoBehaviour
{
    // identifying objects
    GameObject CollidingObject;
    public GameObject objectInHand = null;

    public bool objectGrabbed = false;
    public bool objectReleased = false;

    FixedJoint joint;
    public GameObject hand;
   
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }    

    Vector3 velocity;
    Vector3 angularVelocity;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void Start()
    {
        joint = transform.GetComponent<FixedJoint>();
    }

    private void FixedUpdate()
    {
        //if (objectInHand != null)
        //{
        //    if (objectGrabbed && !objectReleased)
        //    {
        //        objectInHand.transform.position = hand.transform.position;
        //        objectInHand.transform.rotation = hand.transform.rotation;
        //        objectInHand.GetComponent<Rigidbody>().useGravity = false;
        //        objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        //    }
        //}

        velocity = Controller.velocity;
        //angularVelocity = Controller.angularVelocity;
        Debug.Log("Controller Velocity!" + velocity);
        Debug.Log(Controller);
    }

    //when the controllers collide with the grabbable object
    //picking up objects with rigidbodies
    public void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.GetComponent<Rigidbody>() && other.gameObject.tag == "grabbable" || other.gameObject.tag == "2HandGrab")
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
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    //removing parentchild relationship so you drop the object
    public void ReleaseObject()
    {
        objectReleased = true;
        objectGrabbed = false;
        if (objectInHand != null)
        {
            objectInHand.GetComponent<Rigidbody>().useGravity = true;
            objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        }
        joint.connectedBody = null;
        objectInHand = null;
    }

}
