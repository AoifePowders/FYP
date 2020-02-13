using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    public Button button;
    RaycastHit hit;
    public Image image;

    bool clicked = false;
    bool buttonHit = false;

    private void Start()
    {      
    }

    public void CastRay()
    {
        if (GetComponent<SteamVR_LaserPointer>() != null)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                if (hit.collider.CompareTag("UI"))
                {
                    GetComponent<SteamVR_LaserPointer>().thickness = 0.01f;
                }
                else
                {
                    GetComponent<SteamVR_LaserPointer>().thickness = 0;
                }

                if (hit.collider.CompareTag("UIButton"))
                {
                    buttonHit = true;
                    GetComponent<SteamVR_LaserPointer>().thickness = 0.01f;
                    if (!clicked)
                    {
                        button.GetComponent<Button>().image.color = Color.green;
                    }
                }
                else
                {
                    buttonHit = false;
                    button.GetComponent<Button>().image.color = Color.white;
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
            button.GetComponent<Button>().image.color = Color.blue;
            image.color = Color.cyan;
        }
    }

    public void onRelease()
    {
        clicked = false;
        if (buttonHit)
        {
            button.GetComponent<Button>().image.color = Color.green;
        }
    }
}
