using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRandomColorChange : MonoBehaviour
{
    int count = 0;
    GameObject child;
    bool start = false;
    public GameObject buttonStart;

    // Update is called once per frame
    void Update()
    {
        //Button Game
        start = buttonStart.GetComponent<ButtonGameTimer>().start;
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
        else
        {
            changeBack();
            Debug.Log("here");
        }
    }

    void randColor()
    {
        Color RandomColor = new Color(0, 0, 1);
        child.GetComponentInChildren<Renderer>().material.color = RandomColor;
        child.transform.GetChild(0).name = "Active";
    }

    void changeBack()
    {
        Color RandomColor = new Color(1, 0.50f, 0);
        child.GetComponentInChildren<Renderer>().material.color = RandomColor;
        child.transform.GetChild(0).name = "Button";
    }
}
