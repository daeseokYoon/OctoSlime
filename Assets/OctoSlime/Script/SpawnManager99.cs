using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager99 : MonoBehaviour
{
    public float sx = -2.5f;
    public float ex = 2.5f;
    public float startTime = 1;
    public float SpawnStop = 5;
    public GameObject monster;
    public GameObject Boss;

    bool swi = true;
    bool swi2 = true;
    bool swi3 = true;

    [SerializeField]
    GameObject WaningText;

    public GameObject Panel;

    private void Awake()
    {
        WaningText.SetActive(false);
    }

    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("SpStop", SpawnStop);
        Invoke("Xpanel", 1);
    }
    
    void Xpanel()
    {
        Panel.SetActive(false);
    }

    void SpStop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");

        StartCoroutine("RandomSpawn3");

        Invoke("Stop3", SpawnStop - 3);
    }

    void Stop3()
    {
        swi3 = false;

        StopCoroutine("RandomSpawn3");

        StartCoroutine("RandomSpawn2");

        Invoke("Stop2", SpawnStop + 10);
        
    }

    void Stop2()
    {
        //swi2 = false;

        Vector3 pos = new Vector3(0, 4.22f, 0);

        WaningText.SetActive(true);

        Instantiate(Boss, pos, Quaternion.identity);
    }

    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            
            int a =Random.Range(0, 10);
            if (a >= 0 && a < 5)
            {
                float Y = Random.Range(1f, 4f);
                Vector2 sxX = new Vector2(sx, Y);
                //for (int j = 0; j < 3; ++j)// j++ ++j // �̰� ������ �ߺ������� 3�� ���� ��ġ�� ���ͼ� �׷��ſ���.
                    Instantiate(monster, sxX, Quaternion.identity);
                yield return new WaitForSeconds(3f);
            }
            else if(a >= 5 && a< 10)
            {
                float Y = Random.Range(1f, 4f);
                Vector2 exX = new Vector2(ex, Y);
                //for (int k = 0; k < 3; ++k)
                    Instantiate(monster, exX, Quaternion.identity);
                yield return new WaitForSeconds(3f);
            }
            // �� ���� �����ؼ� ���ʿ��� �� ���� �����ؼ� �����ʿ��� ������ �ϰ���� 
            // �ٽ� �����
        }
    }

    int create = 3; // ���� ����
    float interval = 0; // ����ü �� �ʺ�
    bool zig = false;

    IEnumerator RandomSpawn3()  // Ⱦ�� ����
        // Ⱦ�� ������ ����� ���� ������ ������ �ӵ��� ������� ����? �ڷ�ƾ���� ���� ��ŸƮ�ڷ�ƾ x2
    {
        while (swi3)
        {
            if(zig == false)
            {
                for (int i = 0; i < create; i++)
                {
                    float X = sx + interval;
                    Vector2 sxX = new Vector2(X, 3);
                    Instantiate(monster, sxX, Quaternion.identity);
                    zig = true;
                    yield return new WaitForSeconds(0.5f);
                }
            }
            if (zig == true)
            {
                for (int i = 0; i < create; i++)
                {
                    float X = ex + interval;
                    Vector2 exX = new Vector2(X, 3);
                    Instantiate(monster, exX, Quaternion.identity);
                    zig = false;
                    yield return new WaitForSeconds(0.5f);
                }
            }
            interval += 1;
        }
    }

    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            yield return new WaitForSeconds(2f);
            float X = Random.Range(sx, ex);
            Vector2 r = new Vector2(X, transform.position.y);

            Instantiate(monster, r, Quaternion.identity);
        }
      
    }


    void Update()
    {
        
    }
}
