using UnityEngine;

public class InfiniteStarfield : MonoBehaviour
{
    private Transform tx;
    private ParticleSystem.Particle[] points;

    public int starsMax = 100;
    public float starSize = 1;
    public float starDistance = 10;
    public float starClipDistance = 1;

    private float starDistanceSqr;
    private float starClipDistanceSqr;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(starDistance);
        tx = this.transform;
        starDistanceSqr = starDistance * starDistance;
        starClipDistanceSqr = starClipDistance * starClipDistance;
    }
     
    private void CreateStars()
    {
       // Debug.Log("CreateStars");

        points = new ParticleSystem.Particle[starsMax];

        //카메라 위치에서 반지름 starDistance인 구 안에 별이 생성됨
        for(int i =0; i < starsMax; i++)
        {
            points[i].position = tx.position + Random.insideUnitSphere * starDistance;
            points[i].color = new Color(1, 1, 1, 1);
            points[i].size = starSize;
            //ebug.Log(points[i].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (points == null) CreateStars();

        for(int i = 0; i < starsMax; i++)
        {
            //현재 위치에서 별이 너무 멀어졌을때, 별의 위치를 재정의
            if((points[i].position - tx.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = tx.position + Random.insideUnitSphere.normalized * starDistance;
                //Debug.Log(tx.position);
            }

            //별이 카메라에 가까이 왔을때 알파값을 줄임, 너무 커 보이는 것을 방지하기 위해
            if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr)
            {
                float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistanceSqr;
                points[i].color = new Color(1, 1, 1, percent);
                points[i].size = percent * starSize;
                //Debug.Log(percent);
            }
        }

        GetComponent<ParticleSystem>().SetParticles(points, points.Length);
        
    }
}
