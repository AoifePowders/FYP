using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMoveObjects : MonoBehaviour
{
    public GameObject car;

    public string degreeOfMovement;

    private void Update()
    {
        switch(degreeOfMovement)
        {
            case "Horizontal":
                if (transform.eulerAngles.x <= 70 && transform.eulerAngles.x >= 15)
                {
                    car.transform.position += Vector3.right * 0.005f;
                }

                if (transform.eulerAngles.x <= 340 && transform.eulerAngles.x >= 285)
                {
                    car.transform.position += Vector3.left * 0.005f;
                }
                break;
            case "Vertical":
                if (transform.eulerAngles.x <= 70 && transform.eulerAngles.x >= 15)
                {
                    car.transform.position += Vector3.forward * 0.005f;
                }

                if (transform.eulerAngles.x <= 340 && transform.eulerAngles.x >= 285)
                {
                    car.transform.position += Vector3.back * 0.005f;
                }
                break;
        }

    }

}
