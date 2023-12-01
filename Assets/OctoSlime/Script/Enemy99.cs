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


    void FixedUpdate() // ���� �ʿ� �� �� ���� �� �ʿ�����
    {
        if(player != null) 
        { 
            float distance = Vector3.Distance(transform.position, player.transform.position);

            dir = targetPos.transform.position - transform.position;

            if (distance <= range) // �Ÿ��� ��Ÿ� �� �϶� ���󰡶�
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
         
      

        
        // ���͵� �Ѿ�ó�� �÷��̾� �������� ��� �����̰� �ڵ�
        // �ǰ� 0�� �Ǹ� �̵��� ���߰� 2�� �Ŀ� �ı��Ǹ鼭 ���� źȯ�� ����. 
        // �κ�ũ(��� ������, ���� �ð�)    
    }


    public int coincnt = 0; // �ۺ��� ���ٸ�?

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
            Destroy(gameObject); // ������Ʈ ����, ��Ȱ��ȭ �ƴ�.
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
            player.GetComponent<Player99>().GetGage(gage); // 3�� ������ �Ǽ� ã��.
            // ������ ���� ���� ������ �� �� �ִ�. // ���������� Ȯ���� 50% �״�� ����Ǵ� �� �ƴ϶� ������ ����Ǽ� �ö󰡴� ��.
            // �׷��ٸ� �ѹ� �°� �� �ʰ� enemy�� ���� ���·� ���� �ʿ� ����. Ȥ�� ���⸦ ��� ������ �������.
            GameManager99.instance.AddScore(1);
            ItemDrop();
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // ������ ��� Ȯ�� �ֱ�
    public void ItemDrop()
    {
        int a = Random.Range(0, 100);
        if(a >= 50) // Ȯ�� �ֱ�
        {
            Instantiate(Coin, transform.position, Quaternion.identity);
            Instantiate(Item, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }

    //public void CoinShield() // �ᱹ �����ϳ�.
    //{
    //    player.GetComponent<Player99>().coincnt += 1; // ������ ���ӿ�����Ʈ ������ �÷��̾ ã�� �÷��̾��� �̸��� ��ũ��Ʈ�� coincnt�� ��´�. 

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
