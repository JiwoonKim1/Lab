using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backFarStars : MonoBehaviour
{
    private ParticleSystem.Particle[] points;

    public int starsMax = 100;

    public float starSize1 = 0.007f;
    public float starSize2 = 0.009f;

    public float speed1 = 0.8f;
    public float speed2 = 0.6f;

    public float respawnPoint1 = -2f;
    public float respawnPoint2 = -5f;

    public float respawnRadius1 = 0.9f;
    public float respawnRadius2 = 0.85f;

    public float starClipDistance = 0.7f;

    public GameObject backPoint;

    public Camera camera;

    private float starClipDistanceSqr;

    // Start is called before the first frame update
    void Start()
    {
        starClipDistanceSqr = starClipDistance * starClipDistance;
    }

    private Vector3 setPos()
    {
        Vector3 pos = new Vector3(0, 0, Random.Range(respawnPoint1, respawnPoint2));
        pos += Random.onUnitSphere.normalized * Random.Range(respawnRadius1, respawnRadius2);
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
            points[i].position = Vector3.MoveTowards(points[i].position, backPoint.transform.position, Random.Range(speed1, speed2) * Time.deltaTime);

            //위치 재지정
            if (Vector3.Distance(points[i].position, backPoint.transform.position) < 0.3f)
            {
                points[i].position = setPos();
                points[i].size = Random.Range(starSize1, starSize2);
                points[i].color = new Color(1, 1, 1, 1);
            }

            //별이 카메라에 가까이 왔을때 알파값을 줄임, 너무 커 보이는 것을 방지하기 위해
            if ((points[i].position - backPoint.transform.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - backPoint.transform.position).sqrMagnitude / starClipDistanceSqr;

                points[i].color = new Color(1, 1, 1, percent);
                points[i].size *= percent;
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
