using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TestGripButton : MonoBehaviour
{
    private ActionBasedController controller;
    bool isPressed;
    bool isPressed2;
    [SerializeField] private Text number;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("1");
        controller = GetComponent<ActionBasedController>();
        Debug.Log(controller);
    }

    // Update is called once per frame
    void Update()
    {
        //isPressed = controller.selectAction.action.ReadValue<bool>();
        isPressed = controller.activateAction.action.ReadValue<bool>();
        //isPressed2 = controller.uiPressAction.action.ReadValue<bool>();
        isPressed2 = controller.selectAction.action.ReadValue<bool>();


        if (isPressed)
        {
            Debug.Log("isPressed");
            UpNumber();
        }
        if (isPressed2) Debug.Log("isPressed2");
    }

    void UpNumber()
    {
        int num = int.Parse(number.text.ToString()) + 1;
        number.text = num.ToString();
    }
}
