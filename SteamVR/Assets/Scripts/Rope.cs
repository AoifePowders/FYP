using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject partPrefab, parentObject;
    
    public int length = 1;

    float partDistance = 0.21f;

    public bool reset, spawn, snapFirst, snapLast;

    // Update is called once per frame
    void Update()
    {
        if(reset)
        {
            //foreach (GameObject temp in GameObject.FindGameObjectWithTag("Rope"))
            //{
            //    Destroy(temp);
            //}

            reset = false;
        }

        if(spawn)
        {
            Spawn();

            spawn = false;
        }
    }

    public void Spawn()
    {
        int count = (int)(length / partDistance);

        for(int i = 0; i < length; i++)
        {
            GameObject temp;

            temp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y + partDistance * (i + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            temp.transform.eulerAngles = new Vector3(180, 0, 0);

            temp.name = parentObject.transform.childCount.ToString();

            if(i == 0)
            {
                Destroy(temp.GetComponent<CharacterJoint>());
                if (snapFirst)
                {
                    temp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                temp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }

        if (snapLast)
        {
            parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
