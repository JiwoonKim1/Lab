using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onUnitShpereTest : MonoBehaviour
{
    private ParticleSystem.Particle[] points;

    public int starsMax = 100;
    public float starSize = 1f;
    public float bigRadius = 8f;
    public float smallRadius = 4f;

    private float delta;

    // Start is called before the first frame update
    void Start()
    {
        delta = bigRadius - smallRadius;

        CreateStars();

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
    }


    private Vector3 setStars()
    {
        
        float length = delta * Random.value;
        Vector3 pos = Random.onUnitSphere * smallRadius;
        pos *= length;

        Debug.Log(pos);
        
        //Vector3 pos = Random.onUnitSphere * smallRadius;
        return pos;
    }

    private void CreateStars()
    {

        points = new ParticleSystem.Particle[starsMax];

        //카메라 위치에서 반지름 starDistance인 구 안에 별이 생성됨
        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = setStars();
            points[i].color = new Color(1, 0, 0, 1);
            points[i].size = starSize;
        }
    }
}
