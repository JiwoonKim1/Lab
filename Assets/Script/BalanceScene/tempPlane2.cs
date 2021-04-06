using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlane2 : MonoBehaviour
{
    public float defaultSec;
    public float defaultAngle;
    public float turnSpeed = 10f;

    private float myAngle;

    // Start is called before the first frame update
    void Start()
    {
        myAngle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
