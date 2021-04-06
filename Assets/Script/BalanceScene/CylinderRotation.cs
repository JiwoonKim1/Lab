using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CylinderRotation : MonoBehaviour
{
    public float degreePerSec = 0;

    //private float x = 0;

    // Update is called once per frame
    void Update()
    {
        //x += Time.deltaTime * degreePerSec;
        //transform.rotation = Quaternion.Euler(0, x, 0);
        transform.Rotate(new Vector3(0, degreePerSec, 0) * Time.deltaTime);
        Debug.Log("rotation: " + transform.eulerAngles + ", time:" + System.DateTime.Now.ToString("HH:mm:ss.ff"));
    }
}
