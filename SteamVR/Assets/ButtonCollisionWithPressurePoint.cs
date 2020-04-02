using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCollisionWithPressurePoint : MonoBehaviour
{
    public Text scoreText;

    private void Update()
    {
        if (this.name == "Button")
        {
            transform.GetComponent<BoxCollider>().enabled = false;
        }
        else if(this.name == "Active")
        {
            transform.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ButtonPressurePoint")
        {
            if (this.name == "Active")
            {
                scoreText.GetComponent<ButtonScore>().score++;
                scoreText.text = "Score: " + scoreText.GetComponent<ButtonScore>().score;
                this.name = "Button";
            }
        }
    }
}
