using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    Button[] buttons;
    RaycastHit hit;
    public Transform panel;
    public Button startButton;

    bool clicked = false;
    bool buttonHit = false;
    bool otherButtonHit = false;

    public bool playGame = false;
    public bool startTimer = false;

    int score = 0;
    public Text scoreText;

    public LineRenderer _line;

    private void Start()
    {
        _line = gameObject.GetComponent<LineRenderer>();
        _line.enabled = true;
        buttons = panel.GetComponentsInChildren<Button>();
    }

    public void CastRay()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            //Checks if the ray has hit a waypoint and creates a line renderer
            //makes the ray fropm controller if the ray hits UI
            if (hit.collider.CompareTag("UI") || hit.collider.CompareTag("UIButton") || hit.collider.CompareTag("WayPoint") || hit.collider.CompareTag("UIButton") && hit.collider.name == "StartButton")
            {
                _line.enabled = true;
                _line.SetPosition(0, transform.position);
                _line.SetPosition(1, hit.point);
            }
            else
            {
                _line.enabled = false;
            }

            //starts the game if the ray hits and clicks the start button
            if (hit.collider.CompareTag("UIButton") && hit.collider.name == "StartButton")
            {
                buttonHit = true;

                if (!clicked)
                {
                    startButton.GetComponent<Button>().image.color = Color.green;
                }
            }
            else
            {
                buttonHit = false;
                startButton.GetComponent<Button>().image.color = Color.white;
            }

            //anything to do with all other buttons in the game
            if (hit.collider.CompareTag("UIButton"))
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i].transform.position == hit.collider.transform.position && buttons[i].name == "Active")
                    {
                        otherButtonHit = true;
                    }
                }
            }
        }

    }

    private void Update()
    {
        CastRay();
    }

    public void onClick()
    {
        clicked = true;

        if (buttonHit)
        {
            startButton.GetComponent<Button>().image.color = Color.blue;
            playGame = true;
            startTimer = true;
        }

        if (otherButtonHit)
        {
            score++;
            scoreText.text = "Score: " + score;
            this.tag = "Button";
        }
    }

    public void onRelease()
    {
        clicked = false;
        startTimer = false;

        if (buttonHit)
        {
            startButton.GetComponent<Button>().image.color = Color.green;
        }
    }
}
