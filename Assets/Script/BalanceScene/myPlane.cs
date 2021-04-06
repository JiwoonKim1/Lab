using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlane : MonoBehaviour
{
    //텍스처가 적용된 컴포넌트에 부착

    public float defaultTime; 

    private Material material;
    private Texture texture;
    private Shader shader;

    private float time;
    private string[] properties;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        texture = this.GetComponent<Texture>();

        shader = material.shader;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float dir = material.GetFloat("_Direction");
        Debug.Log(dir);
        //if (setTimer()) changeDirection(material.GetFloat("_Direction"));
    }

    private bool setTimer()
    {
        if (time >= defaultTime)
        {
            time = 0f;
            return false;
        }

        time += Time.deltaTime;
        return true;
    }

    private void changeColor(Color color1, Color color2)
    {
        color1 = new Color(color1.r + 10, color1.g + 5, color1.b + 3);
        color2 = new Color(color2.r + 10, color2.g + 5, color2.b + 3);

        material.SetColor("Color1", color1);
        material.SetColor("Color2", color2);
    }

    private void changeTiling(int tileNum)
    {
        tileNum++;

        material.SetInt("_Tiling",  tileNum);
    }

    private void changeDirection(float dir)
    {
        dir += 0.1f;

        material.SetFloat("_Direciton", dir);
    }

    private void changeWarpScale(float scale)
    {
        scale += 0.1f;

        material.SetFloat("_WarpScale", scale);
    }
}
