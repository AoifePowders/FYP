using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerGrabbable : MonoBehaviour
{
    public Transform handle;

    GameObject right;
    GameObject left;

    GrabbingandReleasingObjects garoRight;
    GrabbingandReleasingObjects garoLeft;

    GameObject[] drawers;
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
        for (int i = 0; i < SaveList.Count; i++)
        {
            if (garoRight.objectReleased || garoLeft.objectReleased)
            {
                drawers[i].transform.position = SaveList[i];
            }
        }

        this.GetComponent<Rigidbody>().useGravity = false;
    }

}
