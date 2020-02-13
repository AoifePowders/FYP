using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGrabbable : MonoBehaviour
{
    public Transform handle;

    GameObject right;
    GameObject left;

    GrabbingandReleasingObjects garoRight;
    GrabbingandReleasingObjects garoLeft;

    GameObject[] drawers;
    int counter = 0;
    List<Vector3> SaveList;

    private void Start()
    {
        right = FindObjectOfType<GameManager>().rightHand;
        left = FindObjectOfType<GameManager>().leftHand;

        garoRight = right.GetComponent<GrabbingandReleasingObjects>();
        garoLeft = left.GetComponent<GrabbingandReleasingObjects>();

        drawers = GameObject.FindGameObjectsWithTag("Drawer");

        SaveList = new List<Vector3>();
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Drawer");
        foreach (GameObject GO in objectsWithTag)
        {
            SaveList.Add(GO.transform.position);//use GO.transform to add the transform in the list
        }
    }

    void Update()
    {
        counter = 0;
        if (garoRight.objectReleased || garoLeft.objectReleased)
        {
            transform.position = handle.transform.position;
            transform.rotation = handle.transform.rotation;
            for (int i = 0; i < SaveList.Count; i++)
            {
                drawers[i].transform.position = SaveList[i];
            }
        }

        this.GetComponent<Rigidbody>().useGravity = false;
    }

}
