using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mboss99 : MonoBehaviour
{
    int flag = 1;
    int speed = 2;
    public float Hp = 600; // ���� Hp�� 300�� �ȴٸ� ������ �߻� // ���߿� ȥ�ڼ�...
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
    // UI �߰� ����, ������ ���̶� ����
    bool swit = true;
    bool swit2 = true;
    bool swit3 = true;

    float pattenEnd = 3.0f;

    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        Invoke("Hide", 2); // ���� ǥ�ô� �����Ŵ������� ���� ����
        Invoke("Str", 2);
        Invoke("Stop", pattenEnd); // �ǰ� 300 ���� �϶� ����ǵ��� �ϰ� �;��µ�... ����.
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

        Invoke("Stop2", pattenEnd + 2); // ������� ���� ��Ű���� �̹� ������ �ð��� + ���ڸ� ������� X // Ʋ�� ���ε� �Ʒ��� ����
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
        Readysign.SetActive(false); // �����δ� SetActive ���� �ν���Ʈ�� ����... ���� ��� �� ���� ���� ����� ����
        Lazer.SetActive(false);
        // �ڷ�ƾ�� ����ٰ� �����ִ� ���� ������ ����. // �ڷ�ƾ, �κ�ũ�� �ð��� ����ǰ� ����� ���� �����ϱ� ����.
        StopCoroutine("LazerOn");

        StartCoroutine("BossMissle"); // ���� ������.
    }
    IEnumerator BossMissle()
    {
        while (swit)
        {
            Instantiate(normalB, pos3.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator CircleFire() // 360���� �����.
    {
        float attackRate = 5f;
        int count = 10;
        float intervalAngle = 360 / count;
        float weightAngle = 0;

        while (true)
        {
            for (int i = 0; i < count; i++) // ���� ī��Ʈ�� 2.0������ �ݿ�?
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

    //float Cspeed = 1; // �ӵ�
    //float radius = 1; // ������
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
        Hp -= attack; // ü�¹� ����� �� int���� float ����� ��...
        
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
