using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class changeNumber : MonoBehaviour
{
    [SerializeField] InputActionAsset controls;
    InputAction button;
    InputAction joystick;
    InputAction keyboard;

    // Start is called before the first frame update
    void Start()
    {
        var gameplayActionMap = controls.FindActionMap("Controller");
        var gameplayActionMap2 = controls.FindActionMap("keyboard");

        button = gameplayActionMap.FindAction("PressedButton");
        joystick = gameplayActionMap.FindAction("joyStick");
        keyboard = gameplayActionMap2.FindAction("keyboard");

        button.performed += PressedButton;
        joystick.performed += TouchedJoyStck;
        button.Enable();
        joystick.Enable();

        keyboard.performed += actionPerformed;
        keyboard.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void actionPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("action Performed");
    }
    public void PressedButton(InputAction.CallbackContext context)
    {
        Debug.Log("PressedButton");
    }

    public void TouchedJoyStck(InputAction.CallbackContext context)
    {
        Debug.Log("TouchedJoyStck");
    }
}
