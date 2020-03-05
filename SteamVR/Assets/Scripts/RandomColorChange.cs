using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorChange : MonoBehaviour
{
    int count = 0;
    float rand = 0;
    GameObject child;
    // Update is called once per frame
    void Update()
    {    
        count += 1;
        if(count == 100)
        {
            child = transform.GetChild(Random.Range(0, this.gameObject.transform.childCount)).gameObject;
            randColor();
        }
        if(count > 200)
        {
            changeBack();
            count = 0;
        }
    }

    void randColor()
    {
        Color RandomColor = new Color(0, 0, 1);        
        child.GetComponentInChildren<Renderer>().material.color = RandomColor;
    }

    void changeBack()
    {
        Color RandomColor = new Color(1, 0.50f, 0);
        child.GetComponentInChildren<Renderer>().material.color = RandomColor;
    }
}
