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

    public GameObject nogage; // 사용하려는 것보다 상위에 있는 것으로 불러와야
                              // GameObject의 SetAcive 사용

    bool notDead = true; // 죽는 조건이랑 텍스트 뜨는 거랑 다름. 초기 상태를 false로 해놓으니 초반에 섞임
    [SerializeField]
    GameObject Textnotdead; // 깨우고 나발이고 그냥 담아서 가져오면 그냥 실행 잘되네

    //int x;


    private void Awake()
    {
        Screen.SetResolution(600, 2020, true);
    }
    void Start()
    {
        ani = GetComponent<Animator>();
       //shield = GetComponent<GameObject>(); 
       // 이게 작성되어 있어서 방어막이 제대로 작동이 안됐음. 이미 불러왔는데 또 컴포넌트를 담았으니 에러가 나는 게 당연
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
            L_sword.transform.Rotate(0, 0, 50); // 방향, 속도
            if (L_sword.transform.position.z >= 180f) // 좌표
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
            R_sword.transform.Rotate(0, 0, -50); // 방향, 속도
            if (R_sword.transform.position.z <= -180f) // 좌표
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

        Gage.fillAmount = GageValue; // 병*이 생각을 못하고 4시간 넘게 허비했다. 변수가 c를 누를 때만 작동하게 만드니까 작동을 안 하지

        //if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바 더미 코드
        //{
        //    if (x == 1)
        //    {
        //        L_sword.transform.Rotate(0, 0, 50); // 방향, 속도
        //        if (L_sword.transform.position.z >= 180f) // 좌표
        //        {
        //            L_sword.transform.rotation = Quaternion.Euler(0, 0, 180f);
        //        }
        //    }
        //    else if (x == 2)
        //    {
        //        R_sword.transform.Rotate(0, 0, -50); // 방향, 속도
        //        if (R_sword.transform.position.z <= -180f) // 좌표
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
           
            // 0.5로 증가한다고 했을때 두 번 눌러도 0.5로 고정됨. 누적이 되지 않았었음. 지금은 잘 되지만... 그 이유는... 알려주지 않겠다 위 참고
          
            if(GageValue >= 1) { GageValue = 1; }
            // 0.5 이하에서 게이지가 깎일 일 없이 만듬.
            
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
           
            notDead = !notDead; // notDead false = notDead true 이 상태에서 한 번 클릭하면
                                // notDead가 true >> 여기서 !notDead는 false 상태 // 위는 !notDead가 true 상태
                                // 그래서 번갈아가며 누르면 켰다 꺼지는 것임.
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

    // 실드 중복 생성 막기 + 배열을 이용해서 실드 강화되는 효과 
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
        else Destroy(instance[power]); // 혹시 모를 에러 때문에 다른 상황에서 전부 파괴 되도록 했음
    }

    public void GetGage(float num) // 적을 처치하면 전체 변수로 선언한 게이지 값이 추가됨.
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
