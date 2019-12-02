using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    //select lable from inspector
    //find object that corresponds to label
    //get label of user selection
    //find the object in dictionary
    //use the object we found

    static readonly Dictionary<string, InputFeatureUsage<bool>> availableFeatures = new Dictionary<string, InputFeatureUsage<bool>>
    {
        { "triggerButton", CommonUsages.triggerButton },
        { "gripButton", CommonUsages.gripButton },
        { "thumbrest", CommonUsages.thumbrest },
        { "primary2DAxisClick", CommonUsages.primary2DAxisClick },
        { "primary2DAxisTouch", CommonUsages.primary2DAxisTouch },
        { "menuButton", CommonUsages.menuButton },
        { "secondaryButton", CommonUsages.secondaryButton },
        { "secondaryTouch", CommonUsages.secondaryTouch },
        { "primaryButton", CommonUsages.primaryButton },
        { "primaryTouch", CommonUsages.primaryTouch },


    };

    public enum FeatureOptions
    {
        triggerButton,
        gripButton,
        thumbrest,
        primary2DAxisClick,
        primary2DAxisTouch,
        menuButton,
        secondaryButton,
        secondaryTouch,
        primaryButton,
        primaryTouch
    };

    //creates a drop down menu in unity inspector 
    //for you to choose if right or left hand
    [Tooltip("Input device role (left/right hand)")]
    public InputDeviceRole deviceRole;

    [Tooltip("Select an input feature")]
    public FeatureOptions feature;

    [Tooltip("Event when button starts being pressed")]
    public UnityEvent OnPress;

    [Tooltip("Event when button is realeased")]
    public UnityEvent OnRelease;

    //keep track of if we are pressing button
    bool isPressed;

    //devices that are detected
    List<InputDevice> devices;

    //kepps velue of button press
    bool inputValue;

    //selected feature object (button)
    InputFeatureUsage<bool> selectedFeature;

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
            if(devices[i].TryGetFeatureValue(selectedFeature, out inputValue) && inputValue)
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
