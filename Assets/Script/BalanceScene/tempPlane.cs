
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlane : MonoBehaviour
{
    public float defaultSec;
    public float defaultAngle;
    public float turnSpeed = 10f;

    private float myAngle;

    private void Start()
    {
        myAngle = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0f, 0f, 5f) * Time.deltaTime);
        /*
        if (myAngle >= 180) myAngle -= 180;
        myAngle += (defaultAngle / defaultSec) * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(90f, 0f, myAngle);
        */
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
    }
}
