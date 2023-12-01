using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player99 : MonoBehaviour
{
    public float speed = 1.0f;
    Animator ani;

    public int attack = 100;

    public GameObject L_sword;
    public GameObject R_sword;
    public GameObject[] shield;
    public Transform pos = null;

    public Image Gage;
    public GameObject Slice;
    public float GageValue = 0;

    public GameObject nogage; // ����Ϸ��� �ͺ��� ������ �ִ� ������ �ҷ��;�
                              // GameObject�� SetAcive ���

    bool notDead = true; // �״� �����̶� �ؽ�Ʈ �ߴ� �Ŷ� �ٸ�. �ʱ� ���¸� false�� �س����� �ʹݿ� ����
    [SerializeField]
    GameObject Textnotdead; // ����� �����̰� �׳� ��Ƽ� �������� �׳� ���� �ߵǳ�

    //int x;


    private void Awake()
    {
        Screen.SetResolution(600, 2020, true);
    }
    void Start()
    {
        ani = GetComponent<Animator>();
       //shield = GetComponent<GameObject>(); 
       // �̰� �ۼ��Ǿ� �־ ���� ����� �۵��� �ȵ���. �̹� �ҷ��Դµ� �� ������Ʈ�� ������� ������ ���� �� �翬
      // x = 1;
    }


    void Update()
    {
        float moveX = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = speed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.Translate(moveX, moveY, 0);

        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }

        if (Input.GetAxis("Horizontal") <= -0.5f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            L_sword.transform.Rotate(0, 0, 50); // ����, �ӵ�
            if (L_sword.transform.position.z >= 180f) // ��ǥ
            {
                L_sword.transform.rotation = Quaternion.Euler(0, 0, 180f);
            }
           // x = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            L_sword.transform.rotation = Quaternion.Euler(0, 0, 0);
            //x = 1;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            R_sword.transform.Rotate(0, 0, -50); // ����, �ӵ�
            if (R_sword.transform.position.z <= -180f) // ��ǥ
            {
                R_sword.transform.rotation = Quaternion.Euler(0, 0, -180f);
            }
            //x = 2;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            R_sword.transform.rotation = Quaternion.Euler(0, 0, 0);
            //x = 2;
        }

        Gage.fillAmount = GageValue; // ��*�� ������ ���ϰ� 4�ð� �Ѱ� ����ߴ�. ������ c�� ���� ���� �۵��ϰ� ����ϱ� �۵��� �� ����

        //if (Input.GetKeyDown(KeyCode.Space)) // �����̽��� ���� �ڵ�
        //{
        //    if (x == 1)
        //    {
        //        L_sword.transform.Rotate(0, 0, 50); // ����, �ӵ�
        //        if (L_sword.transform.position.z >= 180f) // ��ǥ
        //        {
        //            L_sword.transform.rotation = Quaternion.Euler(0, 0, 180f);
        //        }
        //    }
        //    else if (x == 2)
        //    {
        //        R_sword.transform.Rotate(0, 0, -50); // ����, �ӵ�
        //        if (R_sword.transform.position.z <= -180f) // ��ǥ
        //        {
        //            R_sword.transform.rotation = Quaternion.Euler(0, 0, -180f);
        //        }
        //    }

        //    if (Input.GetKeyUp(KeyCode.Space))
        //    {
        //        if (x == 1)
        //        {
        //            L_sword.transform.rotation = Quaternion.Euler(0, 0, 0);
        //        }
        //        else if (x == 2)
        //        {
        //            R_sword.transform.rotation = Quaternion.Euler(0, 0, 0);
        //        }
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.C))
        {
           
            // 0.5�� �����Ѵٰ� ������ �� �� ������ 0.5�� ������. ������ ���� �ʾҾ���. ������ �� ������... �� ������... �˷����� �ʰڴ� �� ����
          
            if(GageValue >= 1) { GageValue = 1; }
            // 0.5 ���Ͽ��� �������� ���� �� ���� ����.
            
            if(GageValue >= 0.5f)
            {
                GameObject go = Instantiate(Slice, pos.position, Quaternion.identity);
                Destroy(go, 0.5f);
                GageValue -= 0.5f;
            }
            else if(GageValue < 0.5f)
            {
                nogage.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.C))
            Invoke("SetActivefalse", 0.5f);

        if (transform.position.x >= 2.5f)
            transform.position = new Vector3(2.5f, transform.position.y, 0);
        if (transform.position.x <= -2.5f)
            transform.position = new Vector3(-2.5f, transform.position.y, 0);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            notDead = !notDead; // notDead false = notDead true �� ���¿��� �� �� Ŭ���ϸ�
                                // notDead�� true >> ���⼭ !notDead�� false ���� // ���� !notDead�� true ����
                                // �׷��� �����ư��� ������ �״� ������ ����.
            if (!notDead)
            {
                Textnotdead.SetActive(true);
            }
            else
            {
                Textnotdead.SetActive(false);
            }
        }

    }
    public void SetActivefalse()
    {
        nogage.SetActive(false);
    }

    // �ǵ� �ߺ� ���� ���� + �迭�� �̿��ؼ� �ǵ� ��ȭ�Ǵ� ȿ�� 
    public void CreateShield()
    {
        GameObject[] instance = new GameObject[4]; // !!
        if (instance[power] != shield[power])
        {
            Instantiate(shield[power], pos.position, Quaternion.identity);
        }
        else if (instance[power] == shield[power])
        {
            Destroy(instance[power]);
        }
        else Destroy(instance[power]); // Ȥ�� �� ���� ������ �ٸ� ��Ȳ���� ���� �ı� �ǵ��� ����
    }

    public void GetGage(float num) // ���� óġ�ϸ� ��ü ������ ������ ������ ���� �߰���.
    {
        GageValue += num;
    }

    public int power = 0;
    public int CoinCnt = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            attack += 100;
            if (attack >= 300)
                attack = 300;

            power += 1;
            if (power >= 3)
                power = 3;

            CreateShield();

            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Coin")
        {
            CoinCnt += 1;
            GameManager99.instance.AddCoin(1);
            Destroy(collision.gameObject);            
        }

        if (!notDead)
        {
            if(collision.CompareTag("bullet") || collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
