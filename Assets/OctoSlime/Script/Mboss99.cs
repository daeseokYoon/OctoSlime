using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mboss99 : MonoBehaviour
{
    int flag = 1;
    int speed = 2;
    public float Hp = 600; // 만약 Hp가 300이 된다면 레이저 발사 // 나중에 혼자서...
    public float MaxHP = 600;

    public GameObject normalB;
    public GameObject circleB;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;

    public GameObject Readysign;
    public GameObject DangerLine;
    public GameObject Lazer;
    // UI 추가 예정, 레이저 길이랑 같이
    bool swit = true;
    bool swit2 = true;
    bool swit3 = true;

    float pattenEnd = 3.0f;

    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        Invoke("Hide", 2); // 워닝 표시는 스폰매니저에서 실행 예정
        Invoke("Str", 2);
        Invoke("Stop", pattenEnd); // 피가 300 이하 일때 실행되도록 하고 싶었는데... 못함.
    }
    void Hide()
    {
        GameObject go = GameObject.Find("WaningText"); 
        go.SetActive(false);
    }
    void Str()
    {
        StartCoroutine(BossMissle());
        StartCoroutine(CircleFire());
       // StartCoroutine(RealCircle());
    }
    void Stop()
    {
        swit = false;

        StopCoroutine("BossMissle");

        StartCoroutine("WaningOn");

        Invoke("Stop2", pattenEnd + 2); // 순서대로 실행 시키려면 이미 지나간 시간에 + 숫자를 해줘야함 X // 틀린 말인듯 아래는 됬음
    }

    void Stop2()
    {
        swit2 = false;

        StopCoroutine("WaningOn");

        StartCoroutine("LazerOn");

        Invoke("Stop3", 1); 
    }

    void Stop3()
    {
        swit3 = false;
        Readysign.SetActive(false); // 앞으로는 SetActive 말고 인스턴트로 쓰자... 보스 잡는 것 만들어서 패턴 만들기 도전
        Lazer.SetActive(false);
        // 코루틴만 멈춘다고 켜져있는 것이 꺼지지 않음. // 코루틴, 인보크는 시간이 연결되게 만들면 조건 지정하기 힘듬.
        StopCoroutine("LazerOn");

        StartCoroutine("BossMissle"); // 새로 안켜짐.
    }
    IEnumerator BossMissle()
    {
        while (swit)
        {
            Instantiate(normalB, pos3.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator CircleFire() // 360도로 비산함.
    {
        float attackRate = 5f;
        int count = 10;
        float intervalAngle = 360 / count;
        float weightAngle = 0;

        while (true)
        {
            for (int i = 0; i < count; i++) // 이쪽 카운트에 2.0나누면 반원?
            {
                GameObject clone = Instantiate(circleB, pos1.position, Quaternion.identity);
                GameObject clone2 = Instantiate(circleB, pos2.position, Quaternion.identity);

                float angle = weightAngle + intervalAngle * i;
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                clone.GetComponent<Cbullet99>().Move(new Vector2(x, y));
                clone2.GetComponent<Cbullet99>().Move(new Vector2(x, y));
            }
            weightAngle += 1;
            yield return new WaitForSeconds(attackRate);
        }
    }

    //float Cspeed = 1; // 속도
    //float radius = 1; // 반지름
    //float runningTime = 0;
    //int Cnt = 3;
    //float interval2 = 0;
    //Vector2 newPos = new Vector2();

    //IEnumerator RealCircle()
    //{
    //    while (swit3)
    //    {
    //        for (int i = 0; i < Cnt; i++)
    //        {
    //            GameObject clone = Instantiate(circleB, pos1.position, Quaternion.identity);
    //            GameObject clone2 = Instantiate(circleB, pos2.position, Quaternion.identity);

    //            runningTime += Time.deltaTime * Cspeed;
    //            float x = radius * Mathf.Cos(runningTime);
    //            float y = radius * Mathf.Sin(runningTime);
    //            newPos = new Vector2(x, y);

    //            clone.GetComponent<Cbullet>().Move(new Vector2(x, y));
    //            clone2.GetComponent<Cbullet>().Move(new Vector2(x, y));
    //        }
    //        interval2 += 1;
    //        yield return new WaitForSeconds(3);


    //    }

    //}

    IEnumerator WaningOn()
    {
        while (swit2)
        {
            Readysign.SetActive(true);
            DangerLine.SetActive(true);
            yield return null;
        }

    }

    IEnumerator LazerOn()
    {
        while (swit3)
        {
            Readysign.SetActive(true);
            if(Player != null)
            {
                Lazer.SetActive(true);
            }
            else if(Player == null)
            {
                Lazer.SetActive(false);
            }

            
            Lazer.SetActive(true);
            DangerLine.SetActive(false);
            yield return null;
        }
       
    }
   
    



    void Update()
    {
        if(transform.position.x >= 1f)
            flag*=-1;
        if(transform.position.x <= -1f) 
            flag*=-1;

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);
    }

    public void GetDamage(float attack)
    {
        Hp -= attack; // 체력바 사용할 때 int말고 float 사용할 것...
        
        float hpGage = Hp / MaxHP;

        GameObject.Find("HP").GetComponent<Slider>().value = hpGage;

        if(Hp <= 0)
        {
            Destroy(gameObject);
            GameManager99.instance.SoundDie();
            GameManager99.instance.SetGameClear();
        }
    }

}
