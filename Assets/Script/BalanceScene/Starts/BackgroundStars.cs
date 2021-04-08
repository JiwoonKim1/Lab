using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStars : MonoBehaviour
{
    private ParticleSystem.Particle[] points;

    public int starsMax = 100;
    public float starSize = 1f;
    public float starClipDistance = 1f;
    public float speed = 1f;
    public Camera camera;

    private Transform tx;

    private Vector3 mySpeed;

    public float bigRadius = 8f;
    public float smallRadius = 4f;

    private float bigRadiusSqr;
    private float smallRadiusSqr;
    private float starClipDistanceSqr;
    private float delta;

    // Start is called before the first frame update
    void Start()
    {
        
        smallRadiusSqr = smallRadius * smallRadius;
        bigRadiusSqr = bigRadius * bigRadius;
        delta = bigRadius - smallRadius;
        starClipDistanceSqr = starClipDistance * starClipDistance;

        tx = this.transform;

        mySpeed = new Vector3(0, 0, speed);

    }


    private void CreateStars()
    {

        points = new ParticleSystem.Particle[starsMax];

        //카메라 위치에서 반지름 starDistance인 구 안에 별이 생성됨
        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = Random.onUnitSphere * bigRadius;
            points[i].color = new Color(1, 1, 1, 1);
            points[i].size = starSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update");
        if (points == null) CreateStars();

        for (int i = 0; i < starsMax; i++)
        {
            points[i].position += mySpeed * Time.deltaTime;

            //별이 카메라에 가까이 왔을때 알파값을 줄임, 너무 커 보이는 것을 방지하기 위해
            if ((points[i].position - tx.transform.position).sqrMagnitude <= smallRadiusSqr)
            {
                float percent = (points[i].position - tx.transform.position).sqrMagnitude / smallRadiusSqr;

                points[i].color = new Color(1, 1, 1, percent);
                points[i].size = percent * starSize;

            }
            /*
            if (((points[i].position).sqrMagnitude < smallRadiusSqr) || ((points[i].position).sqrMagnitude > bigRadiusSqr))
            {
                //Debug.Log("reset");
                float length = delta * Random.value;
                points[i].position = Random.onUnitSphere * (bigRadius - length);
            }
            */

            //speed *  z >0 && 특정거리 이상인 경우 위치 재지정
            if (points[i].position.z * speed > speed * (-1))
            {
                //Debug.Log(points[i].position);
                points[i].position = Random.onUnitSphere * bigRadius;
            }

        }

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);

    }
}
