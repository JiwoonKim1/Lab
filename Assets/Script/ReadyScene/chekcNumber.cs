using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class chekcNumber : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNumberChanged(InputAction.CallbackContext context)
    {
        Debug.Log("onNumberChanged");
        bool isChanged = context.ReadValue<bool>();
        Debug.Log(isChanged);
    }
}
