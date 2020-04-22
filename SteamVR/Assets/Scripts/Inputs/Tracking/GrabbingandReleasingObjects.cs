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

    private Rigidbody rigidbody;

    public GameObject projectile;
    public Transform gun;
    GameObject instantiatedProjectile;

    void Start()
    {
        joint = GetComponent<FixedJoint>();
    }

    private void FixedUpdate()
    {
        //if (throwing)
        //{
        //    Transform origin;
        //    if (trackedObj.origin != null)
        //    {
        //        origin = trackedObj.origin;
        //    }
        //    else
        //    {
        //        origin = trackedObj.transform.parent;
        //    }

        //    if (objectInHand != null)
        //    {
        //        if (origin != null)
        //        {
        //            objectInHand.GetComponent<Rigidbody>().velocity = origin.TransformVector(Controller.velocity);
        //            objectInHand.GetComponent<Rigidbody>().angularVelocity = origin.TransformVector(Controller.angularVelocity * 0.25f);
        //        }
        //        else
        //        {
        //            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
        //            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity * 0.25f;
        //        }

        //        objectInHand.GetComponent<Rigidbody>().maxAngularVelocity = rigidbody.angularVelocity.magnitude;
        //    }

        //    throwing = false;
        //}
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

    public void shoot()
    {
        if (objectInHand.name == "Gun")
        {
            instantiatedProjectile = Instantiate(projectile);
            instantiatedProjectile.transform.position = gun.position;
            instantiatedProjectile.transform.rotation = gun.rotation;
        }
    }

}