using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarStars : MonoBehaviour
{
    private ParticleSystem.Particle[] points;

    public float bigRadius = 0.85f;
    public float smallRadius = 0.8f;

    private float smallRadiusSqr;
    private float delta;

    public int starsMax = 100;

    public float starSize1 = 0.007f;
    public float starSize2 = 0.009f;

    public float speed1 = -0.8f;
    public float speed2 = -0.6f;

    public float respawnPoint1 = 3f;
    public float respawnPoint2 = 6f;

    public float starClipDistance = 0.7f;

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        smallRadiusSqr = smallRadius * smallRadius;
    }

    private Vector3 setPos()
    {
        Vector3 pos = new Vector3(0, 0, Random.Range(respawnPoint1, respawnPoint2));
        pos += Random.onUnitSphere * Random.Range(smallRadius, bigRadius);
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

            //별이 카메라에 가까이 왔을때 알파값을 줄임, 너무 커 보이는 것을 방지하기 위해
            if ((points[i].position - camera.transform.position).sqrMagnitude <= smallRadiusSqr)
            {
                float percent = (points[i].position - camera.transform.position).sqrMagnitude / smallRadiusSqr;

                points[i].color = new Color(1, 1, 1, percent);
                points[i].size *= percent;

            }


            //speed *  z >0 && 특정거리 이상인 경우 위치 재지정
            if (points[i].position.z * speed1 > 0.2f)
            {
                points[i].position = setPos();
                points[i].size = Random.Range(starSize1, starSize2);
                points[i].color = new Color(1, 1, 1, 1);

            }    
        }

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);

    }

}
