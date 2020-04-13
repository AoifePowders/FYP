﻿using System.Collections;
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

    private bool throwing;
    private Rigidbody rigidbody;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        joint = GetComponent<FixedJoint>();
    }

    private void FixedUpdate()
    {


        if (throwing)
        {
            Transform origin;
            if (trackedObj.origin != null)
            {
                origin = trackedObj.origin;
            }
            else
            {
                origin = trackedObj.transform.parent;
            }

            if (objectInHand != null)
            {
                if (origin != null)
                {
                    objectInHand.GetComponent<Rigidbody>().velocity = origin.TransformVector(Controller.velocity);
                    objectInHand.GetComponent<Rigidbody>().angularVelocity = origin.TransformVector(Controller.angularVelocity * 0.25f);
                }
                else
                {
                    objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
                    objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity * 0.25f;
                }

                objectInHand.GetComponent<Rigidbody>().maxAngularVelocity = rigidbody.angularVelocity.magnitude;
            }

            throwing = false;
        }
    }

    private void Update()
    {
        if (objectInHand != null)
        {
            if (objectGrabbed && !objectReleased)
            {
                objectInHand.transform.localPosition = hand.transform.position;
                objectInHand.transform.localRotation = hand.transform.rotation;
                objectInHand.GetComponent<Rigidbody>().useGravity = false;
                objectInHand.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        CastRay();

        var device = SteamVR_Controller.Input((int)trackedObj.index);
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
        throwing = false;

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
            throwing = true;
            //objectInHand.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Rigidbody>().velocity.normalized * 10, ForceMode.Force);
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = gameObject.GetComponent<Rigidbody>().angularVelocity.normalized * 10;

            //Debug.Log(objectInHand.GetComponent<Rigidbody>().velocity);
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