using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollisions : MonoBehaviour
{
    public GameObject[] ropeParts;

    // Start is called before the first frame update
    void Update()
    {
        ropeParts = GameObject.FindGameObjectsWithTag("ropePart");

        foreach (GameObject ropePart in ropeParts)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), ropePart.GetComponent<Collider>());
        }
       
    }
}
