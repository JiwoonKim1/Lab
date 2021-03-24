using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setEyeCenter : MonoBehaviour
{
    //eyeCenter에 부착
    private Vector3 ScreenCenter;

    // Start is called before the first frame update
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        transform.position = ScreenCenter;
    }

}
