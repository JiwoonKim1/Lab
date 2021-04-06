using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static OVRInput;
using UnityEngine.XR;
using System;

public class GripButton : MonoBehaviour
{
    //private UnityEngine.XR.InputDevice _leftDevice;
    private UnityEngine.XR.InputDevice _rightDevice;
    public Text number;

    private void Start()
    {
        //_leftDevice = GetCurrentDevice(XRNode.LeftHand);
        _rightDevice = GetCurrentDevice(XRNode.RightHand);
    }

    private UnityEngine.XR.InputDevice GetCurrentDevice(object rightHand)
    {
        throw new NotImplementedException();
    }



    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            Debug.Log("OnGrip");
            OnGrip();
        }
    }

    void OnGrip()
    {
        int num = int.Parse(number.text.ToString()) + 1;
        number.text = num.ToString();
    }
}
