using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandleTrackingChanges : MonoBehaviour
{
    [Tooltip("Input device role (left / right hand)")]
    public InputDeviceRole deviceRole;

    [Tooltip("Game Object representing controller")]
    public GameObject gameObj;

    // keep devices that are detected
    List<InputDevice> devices;

    // Start is called before the first frame update
    void Awake()
    {
        // init devices list
        devices = new List<InputDevice>();

        // start with the controllers disabled
        gameObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }

    void Check()
    {
        // get the tracked devices for the specified role
        InputDevices.GetDevicesWithRole(deviceRole, devices);

        // if the controller was being shown, and it's not found
        if (gameObj.activeInHierarchy && devices.Count == 0)
        {
            // disable controller
            gameObj.SetActive(false);
        }

        // if the controller was hidden, and now it's found
        else if (!gameObj.activeInHierarchy && devices.Count > 0)
        {
            // enable controller 
            gameObj.SetActive(true);
        }
    }
}
