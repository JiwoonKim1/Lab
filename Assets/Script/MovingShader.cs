using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShader : MonoBehaviour
{
    private Material material;
    public double pos;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        pos = material.GetFloat("_Position");
    }

    // Update is called once per frame
    void Update()
    {
        pos += 0.1;
    }
}
