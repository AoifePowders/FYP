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

    public FixedJoint joint;
    public GameObject hand;

    RaycastHit hit;

    Vector3 velo = new Vector3();

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        joint = GetComponent<FixedJoint>();
    }

    private void FixedUpdate()
    {
        if (objectInHand != null)
        {
            if (objectGrabbed && !objectReleased)
            {
                objectInHand.transform.position = hand.transform.position;
                objectInHand.transform.rotation = hand.transform.rotation;
                objectInHand.GetComponent<Rigidbody>().useGravity = false;
                objectInHand.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    private void Update()
    {
        CastRay();
        // Debug.Log(gameObject.GetComponent<Rigidbody>().velocity.normalized);

        //Debug.Log("object velo" + objectInHand.GetComponent<Rigidbody>().velocity.x);
        //Debug.Log("controller velo" + Controller.velocity.x);
    }

    //when the controllers collide with the grabbable object
    //picking up objects with rigidbodies
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() && other.gameObject.tag == "grabbable" || other.gameObject.tag == "ForceGrab")
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
        CollidingObject = null;

        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    //removing parentchild relationship so you drop the object
    public void ReleaseObject()
    {
        objectReleased = true;
        objectGrabbed = false;
        if (objectInHand != null)
        {
            joint.connectedBody = null;

            objectInHand.GetComponent<Rigidbody>().useGravity = true;
            objectInHand.GetComponent<Rigidbody>().isKinematic = false;
            objectInHand.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Rigidbody>().velocity.normalized * 10, ForceMode.Force);
            objectInHand.GetComponent<Rigidbody>().angularVelocity = gameObject.GetComponent<Rigidbody>().angularVelocity.normalized * 10;

            Debug.Log(objectInHand.GetComponent<Rigidbody>().velocity);
        }
        objectInHand = null;
    }

    public void CastRay()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.CompareTag("ForceGrab"))
            {
                if (objectGrabbed && !objectReleased)
                {
                    hit.transform.position = Vector3.MoveTowards(hit.transform.position, transform.position, 0.1f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ForceGrab"))
        {
            if (objectGrabbed && !objectReleased)
            {
                objectInHand = hit.collider.gameObject;
            }
        }
    }

}