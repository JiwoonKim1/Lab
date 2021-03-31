using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRotation : MonoBehaviour
{
    public float degreePerSec = 0;

    private float totalRot = 0;
    // Update is called once per frame
    void Update()
    {
        if(totalRot < 360)
        {
            transform.Rotate(new Vector3(0, degreePerSec, 0) * Time.deltaTime);
            totalRot += degreePerSec * Time.deltaTime;
        }
    }
}
