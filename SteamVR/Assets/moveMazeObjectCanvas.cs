using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMazeObjectCanvas : MonoBehaviour
{
    public GameObject car;

    public string degreeOfMovement;

    // Update is called once per frame
    void Update()
    {
        if (name == "Active")
        {
            switch (degreeOfMovement)
            {
                case "Up":
                    car.transform.position += Vector3.forward * 0.005f;
                    break;
                case "Down":
                    car.transform.position += Vector3.back * 0.005f;
                    break;
                case "Right":
                    car.transform.position += Vector3.right * 0.005f;
                    break;
                case "Left":
                    car.transform.position += Vector3.left * 0.005f;
                    break;
            }
        }
    }
}
