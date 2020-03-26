using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenuGrabAndThrow : MonoBehaviour
{

    GameObject right;
    public GameObject left;
    public GameObject cubePrefab;

    int pTouched = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        right = FindObjectOfType<GameManager>().rightHand;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (pTouched == 0)
            {
                GameObject temp = Instantiate(cubePrefab, left.transform);
                //temp.tag = "grabbable";
                //Rigidbody tempsRigidBody = temp.AddComponent<Rigidbody>();
                //temp.GetComponent<BoxCollider>().isTrigger = false;
                //temp.GetComponent<Rigidbody>().isKinematic = true;
                //temp.AddComponent<Projectile>();

                pTouched = 1;
                //Destroy(temp.GetComponent<ControllerMenuGrabAndThrow>());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(pTouched == 1)
        {
            pTouched = 0;
        }
    }
}
