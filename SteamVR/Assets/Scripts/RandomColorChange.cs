using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColorChange : MonoBehaviour
{
    int count = 0;
    int UIcount = 0;
    float rand = 0;
    GameObject child;
    Button buttonChild;
    bool start = false;

    // Update is called once per frame
    void Update()
    { 
        //UI Button Game
        //if(ui start button pressed)
        if (this.name == "Buttons")
        {
            //UIcount += 1;
            if (UIcount == 100)
            {
                buttonChild = transform.GetChild(Random.Range(0, this.gameObject.transform.childCount)).GetComponent<Button>();
                randUIColor();
            }
            if (UIcount > 200)
            {
                changeUIBack();
                count = 0;
            }
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Button Game
        start = GameObject.Find("ButtonStart").GetComponent<PlayButtonGame>().playGame;
        if (start)
        {
            count += 1;
            if (count == 100)
            {
                child = transform.GetChild(Random.Range(0, this.gameObject.transform.childCount)).gameObject;
                randColor();
            }
            if (count > 200)
            {
                changeBack();
                count = 0;
            }
        }
    }
    

    void randColor()
    {
        Color RandomColor = new Color(0, 0, 1);
        child.GetComponentInChildren<Renderer>().material.color = RandomColor;
        child.transform.GetChild(0).tag = "Active";
    }

    void changeBack()
    {
        Color RandomColor = new Color(1, 0.50f, 0);
        child.GetComponentInChildren<Renderer>().material.color = RandomColor;
        child.transform.GetChild(0).tag = "Button";
    }

    void randUIColor()
    {
        Color RandomColor = new Color(0, 0, 1);
        buttonChild.image.color = RandomColor;
    }

    void changeUIBack()
    {
        Color RandomColor = new Color(1, 0.50f, 0);
        buttonChild.image.color = RandomColor;
    }

}
