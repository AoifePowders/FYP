using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialrotation : MonoBehaviour
{
    Rigidbody rb;
    bool collision = false;
    GameObject collidedObj;

    Vector3 eulerRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(collision == true)
        {
            eulerRotation = new Vector3(0.0f, 0.0f, collidedObj.transform.eulerAngles.z);
            transform.localRotation = Quaternion.Euler(-eulerRotation);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            collision = true;
            collidedObj = other.gameObject;
        }
    }
    
    // releasing those objects with rigidbodies
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            collision = false;
            collidedObj = null;
        }
    }
}
