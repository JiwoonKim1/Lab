using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStars : MonoBehaviour
{
    private ParticleSystem.Particle[] points;

    public int starsMax = 100;
    public float starSize = 1f;
    public float speed = 1f;
    public Camera camera;

    private Transform tx;

    private Vector3 mySpeed;

    public float bigRadius = 8f;
    public float smallRadius = 4f;

    public float respawnPoint = 2f;

    private float smallRadiusSqr;
    private float delta;
    private Vector3 respawn;

    // Start is called before the first frame update
    void Start()
    {
        
        smallRadiusSqr = smallRadius * smallRadius;
        delta = bigRadius - smallRadius;

        tx = this.transform;

        mySpeed = new Vector3(0, 0, speed);

        respawn = new Vector3(0, 0, respawnPoint);

    }


    private void CreateStars()
    {

        points = new ParticleSystem.Particle[starsMax];

        //카메라 위치에서 반지름 starDistance인 구 안에 별이 생성됨
        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = respawn + Random.onUnitSphere * Random.Range(smallRadius, bigRadius);
            points[i].color = new Color(1, 1, 1, 1);
            points[i].size = starSize;
        }
    }

    // Update is called once per frame
    void Update()
    {

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


            //speed *  z >0 && 특정거리 이상인 경우 위치 재지정
            if (points[i].position.z * speed > 0.5f)
            {
                points[i].position = respawn + Random.onUnitSphere * Random.Range(smallRadius, bigRadius);

            }

            GetComponent<ParticleSystem>().SetParticles(points, points.Length);
        }

    }
}
