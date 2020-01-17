using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandGrab : MonoBehaviour
{
    GameManager manager;
    Rigidbody rb;
    public List<GameObject> HandList = new List<GameObject>(2);
    Vector3 distance;
    float mag;
    Vector3 normalDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Anchor one hand and aim with the other
    void FixedUpdate()
    {
        //1st hand is the anchor
       // rb.MovePosition(HandList[0].gameObject.transform.position);
        //second hand is the aim
        //distance = HandList[1].gameObject.transform.position - HandList[0].gameObject.transform.position;
        //mag = distance.magnitude;
        //normalDirection = distance / mag;

        //transform.position.RotateTowards(manager.leftHand.transform.position);
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, manager.leftHand.transform.position, 1.0f * Time.deltaTime, 0.0f);
        //transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            //if (manager.rightHand.GetComponent<GrabbingandReleasingObjects>().objectGrabbed)
            //{
                HandList.Add(other.gameObject);
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            HandList.Remove(other.gameObject);
        }
    }
}
