using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRotation : MonoBehaviour
{

    public float degreePerSec = 0;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreePerSec) * Time.deltaTime);
    }
}
