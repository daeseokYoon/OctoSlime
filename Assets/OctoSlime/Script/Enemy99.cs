using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy99 : MonoBehaviour
{
    GameObject targetPos;
    GameObject player;
    public float speed = 1f;
    public float range = 1f;
    public GameObject bullet = null;
    public Transform pos3 = null;

    public int Hp = 100;
    public int explosion = 100;

    Vector2 dir;
    Vector2 dirno;

    bool stopshoot = false;

    public GameObject explo;
    public GameObject OctoExplo;

    public GameObject Item;
    public GameObject Coin;
    public GameObject Coin2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetPos = GameObject.Find("targetPos");
        Invoke("CreateBullet", 0.5f);
    }
    void CreateBullet()
    {
        if (stopshoot == false)
        {
            Instantiate(bullet, pos3.position, Quaternion.identity);
            Invoke("CreateBullet", 1f);
        }
    }


    void FixedUpdate() // 복습 필요 좀 더 상세히 알 필요있음
    {
        if(player != null) 
        { 
            float distance = Vector3.Distance(transform.position, player.transform.position);

            dir = targetPos.transform.position - transform.position;

            if (distance <= range) // 거리가 사거리 안 일때 따라가라
            {
                stopshoot = true;
                Vector3 dir2 = player.transform.position - transform.position;
                dir2 = dir2.normalized;

                float mx = dir2.x * speed * Time.deltaTime;
                float my = dir2.y * speed * Time.deltaTime;

                transform.Translate(mx, my, 0); // rb.veloctiy = new Vector2(mx, my);

                GetComponent<SpriteRenderer>().flipX = (mx > 0); // ?

            }
            else
            {
                dirno = dir.normalized;
                transform.Translate(dirno * speed * Time.deltaTime);
            }
        }
        else
        {
            Vector3 vector = Vector3.down;
            transform.Translate(vector*Time.deltaTime);
        }
         
      

        
        // 몬스터도 총알처럼 플레이어 없어져도 계속 움직이게 코드
        // 피가 0이 되면 이동을 멈추고 2초 후에 파괴되면서 원형 탄환이 나옴. 
        // 인보크(잡몹 프리팹, 지연 시간)    
    }


    public int coincnt = 0; // 퍼블릭은 뺀다면?

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject go = Instantiate(explo, transform.position, Quaternion.identity);
            Destroy(go, 1);
            Destroy(collision.gameObject);
            GameManager99.instance.SoundExplosion();
            //GameManager99.instance.CoinPang();
            GameManager99.instance.SetGameOver();
            //CoinShield();
            Destroy(gameObject); // 오브젝트 삭제, 비활성화 아님.
        }
        if (collision.gameObject.tag == "Shield")
        {
            GameObject go = Instantiate(explo, transform.position, Quaternion.identity);
            Destroy(go, 1);
            collision.gameObject.GetComponent<Shield99>().Pang(explosion);
            collision.gameObject.GetComponent<Shield99>().ShieldDown();
            Destroy(gameObject);
        }
    }


    float gage = 0.5f;
    public void GetDamage(int attack)
    {
        Hp -= attack;
        if (Hp <= 0)
        {
            GameObject go = Instantiate(OctoExplo, transform.position, Quaternion.identity);
            Destroy(go, 1);
            GameManager99.instance.SoundDie();
            player.GetComponent<Player99>().GetGage(gage); // 3씩 오르는 실수 찾음.
            // 공격이 빨리 들어가면 여러번 들어갈 수 있다. // 마찬가지로 확률도 50% 그대로 적용되는 게 아니라 여러번 적용되서 올라가는 것.
            // 그렇다면 한번 맞고 몇 초간 enemy를 무적 상태로 만들 필요 있음. 혹은 무기를 기능 정지로 만들던가.
            GameManager99.instance.AddScore(1);
            ItemDrop();
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // 아이템 드랍 확률 넣기
    public void ItemDrop()
    {
        int a = Random.Range(0, 100);
        if(a >= 50) // 확률 넣기
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
            Instantiate(Item, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }

    //public void CoinShield() // 결국 빼야하나.
    //{
    //    player.GetComponent<Player99>().coincnt += 1; // 위에서 게임오브젝트 형태의 플레이어를 찾고 플레이어라는 이름의 스크립트의 coincnt를 담는다. 

    //    if (player.GetComponent<Player99>().coincnt >= 1)
    //    {
    //        for (int i = 0; i < player.GetComponent<Player99>().coincnt; i++)
    //        {
    //            Instantiate(Coin2, transform.position, Quaternion.identity);
    //        }
    //        player.GetComponent<Player99>().coincnt -= player.GetComponent<Player99>().coincnt;
    //        GameManager99.instance.AddCoin(0);
    //    }
    //    else if (player.GetComponent<Player99>().coincnt == 0)
    //    {
    //        Destroy(gameObject);
    //        GameManager99.instance.SetGameOver();
    //    }
    //}



}
