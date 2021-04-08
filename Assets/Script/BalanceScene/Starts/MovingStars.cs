﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStars : MonoBehaviour
{
    private ParticleSystem.Particle[] points;

    public int starsMax = 100;
    public float starSize = 1f;
    public float starClipDistance = 1f;
    public float speed = 1f;
    public Camera camera;
    public float respawnPoint = 4f;
    public float respawnRadius = 1f;

    private float starClipDistanceSqr;
    private Vector3 mySpeed;
    private Vector3 respawn;

    // Start is called before the first frame update
    void Start()
    {
        starClipDistanceSqr = starClipDistance * starClipDistance;

        mySpeed = new Vector3(0, 0, speed);
        respawn = new Vector3(0, 0, respawnPoint);

    }

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];

        //카메라 위치에서 반지름 starDistance인 구 안에 별이 생성됨
        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = respawn + Random.insideUnitSphere * respawnRadius;
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

            //현재 위치에서 별이 너무 멀어졌을때, 별의 위치를 재정의
            /*
            if ((points[i].position - camera.transform.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere * starDistance;
            }
             */
            //speed *  z >0 && 특정거리 이상인 경우 위치 재지정
            if (points[i].position.z * speed > 1f)
            {
                //Debug.Log(points[i].position);
                points[i].position = respawn + Random.insideUnitSphere.normalized * respawnRadius;
            }

            //별이 카메라에 가까이 왔을때 알파값을 줄임, 너무 커 보이는 것을 방지하기 위해
            if ((points[i].position - camera.transform.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - camera.transform.position).sqrMagnitude / starClipDistanceSqr;

                points[i].color = new Color(1, 1, 1, percent);
                points[i].size = percent * starSize;

            }

        }

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);

    }
}
