using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    float speed = 5;
    public GameObject player;
    public GameObject HMD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
