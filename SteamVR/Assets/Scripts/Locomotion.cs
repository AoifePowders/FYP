using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    float speed = 5;
    public GameObject player;
    public GameObject HMD;

    RaycastHit hit;

    public void Move()
    {
        player.GetComponent<Rigidbody>().velocity = HMD.transform.forward * speed;
    }

    public void StopMove()
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void Rotate()
    {
        Quaternion newRotation = Quaternion.AngleAxis(45, Vector3.up);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, player.transform.rotation * newRotation, 1f);
    }

    public void CastRay()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.CompareTag("WayPoint"))
            {
                float pos = player.transform.position.y;
                player.transform.position = new Vector3 (hit.transform.position.x, pos, hit.transform.position.z);
            }
        }
    }
}
