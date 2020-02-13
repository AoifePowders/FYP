using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMoveObjects : MonoBehaviour
{
    public GameObject car;

    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "LeverCollision")
        //{
           // if(other.name == "Forward")
            //{
                Debug.Log("forward");
               // car.transform.position = Vector3.MoveTowards(car.transform.position, Vector3.forward, 1.0f * Time.deltaTime);
            //}
        //}      
    }
}
