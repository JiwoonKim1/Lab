using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosStars : MonoBehaviour
{
    private ParticleSystem.Particle[] points;

    public int starsMax = 100;

    public float starSize1 = 0.008f;
    public float starSize2 = 0.01f;

    public float speed1 = -1f;
    public float speed2 = -0.8f;

    public float respawnPoint1 = 3f;
    public float respawnPoint2 = 4f;

    public float respawnRadius1 = 0.25f;
    public float respawnRadius2 = 0.3f;

    public float starClipDistance = 0.7f;

    public Camera camera;

    private float starClipDistanceSqr;



    // Start is called before the first frame update
    void Start()
    {
        starClipDistanceSqr = starClipDistance * starClipDistance;

    }

    private Vector3 setPos()
    {
        Vector3 pos = new Vector3(0, 0, Random.Range(respawnPoint1, respawnPoint2)) + Random.insideUnitSphere.normalized * Random.Range(respawnRadius1, respawnRadius2);
        return pos;
    }
    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];

        //카메라 위치에서 반지름 starDistance인 구 안에 별이 생성됨
        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = setPos();
            points[i].color = new Color(1, 1, 1, 1);
            points[i].size = Random.Range(starSize1, starSize2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (points == null) CreateStars();

        for (int i = 0; i < starsMax; i++)
        {
            Vector3 mySpeed = new Vector3(0, 0, Random.Range(speed1, speed2));
            points[i].position += mySpeed * Time.deltaTime;

            //현재 위치에서 별이 너무 멀어졌을때, 별의 위치를 재정의
            if (points[i].position.z * speed1 > 0.3f)
            {
                points[i].position = setPos();
                points[i].size = Random.Range(starSize1, starSize2);
                points[i].color = new Color(1, 1, 1, 1);
            }

            //별이 카메라에 가까이 왔을때 알파값을 줄임, 너무 커 보이는 것을 방지하기 위해
            if ((points[i].position - camera.transform.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - camera.transform.position).sqrMagnitude / starClipDistanceSqr;

                points[i].color = new Color(1, 1, 1, percent);
                points[i].size *= percent;
            }

        }

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);

    }
}
