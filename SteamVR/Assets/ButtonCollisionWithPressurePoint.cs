using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCollisionWithPressurePoint : MonoBehaviour
{
    int score = 0;
    public Text scoreText;

    private void Update()
    {
        if (this.CompareTag("Button"))
        {
            transform.GetComponent<BoxCollider>().enabled = false;
        }
        else if(this.CompareTag("Active"))
        {
            transform.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ButtonPressurePoint")
        {
            if (this.CompareTag("Active"))
            {
                score++;
                scoreText.text = "Score: " + score;
                this.tag = "Button";
            }
        }
    }
}
