using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class AxisController : MonoBehaviour
{
    //select lable from inspector
    //find object that corresponds to label
    //get label of user selection
    //find the object in dictionary
    //use the object we found

    static readonly Dictionary<string, InputFeatureUsage<float>> availableFeatures = new Dictionary<string, InputFeatureUsage<float>>
    {
        { "trigger", CommonUsages.trigger },
        { "grip", CommonUsages.grip },
        { "indexTouch", CommonUsages.indexTouch },
        { "thumbTouch", CommonUsages.thumbTouch },
        { "indexFinger", CommonUsages.indexFinger },
        { "middleFinger", CommonUsages.middleFinger },
        { "ringFinger", CommonUsages.ringFinger },
        { "pinkyFinger", CommonUsages.pinkyFinger },
    };

    public enum FeatureOptions
    {
        trigger,
        grip,
        indexTouch,
        thumbTouch,
        indexFinger,
        middleFinger,
        ringFinger,
        pinkyFinger,
    };

    //creates a drop down menu in unity inspector 
    //for you to choose if right or left hand
    [Tooltip("Input device role (left/right hand)")]
    public InputDeviceRole deviceRole;

    [Tooltip("Select an input feature")]
    public FeatureOptions feature;

    [Tooltip("Sensitivity of the axis")]
    [Range(0, 1)]
    public float threshold;

    [Tooltip("Event when button starts being pressed")]
    public UnityEvent OnPress;

    [Tooltip("Event when button is realeased")]
    public UnityEvent OnRelease;

    //keep track of if we are pressing button
    bool isPressed;

    //devices that are detected
    List<InputDevice> devices;

    //kepps velue of button press
    float inputValue;

    //selected feature object (button)
    InputFeatureUsage<float> selectedFeature;

    private void Awake()
    {
        devices = new List<InputDevice>();
        //get label selected by user
        string featureLabel = Enum.GetName(typeof(FeatureOptions), feature);

        //find dictionary entry
        availableFeatures.TryGetValue(featureLabel, out selectedFeature);
    }

    // Update is called once per frame
    void Update()
    {
        //get device we want to check
        //right or left hand controller
        InputDevices.GetDevicesWithRole(deviceRole, devices);
        //go through devices
        for(int i = 0; i < devices.Count; i++)
        {
            //check if button is being pressed
            //check wheather we can read state if button
            //if we can the button value should be true
            if(devices[i].TryGetFeatureValue(selectedFeature, out inputValue) && inputValue > threshold)
            {
                //check if we are already pressing
                if(!isPressed)
                {
                    isPressed = true;

                    //trigger the OnPressevent
                    OnPress.Invoke();
                }
            }
            else if(isPressed)
            {
                //update bool
                isPressed = false;

                //trigger the on release event
                OnRelease.Invoke();
            }
        }

    }
}
