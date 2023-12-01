using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword99 : MonoBehaviour
{
    public int Attack = 100;
   

    void Start()
    {
        
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy99>().GetDamage(Attack);
        }
    }
    // 무기 강화 // 휘두를때만 데미지 들어가게끔 수정 필요 
    // bool 값이랑 조건문으로 어떻게 만들어봐야지 zx 버튼에 true가 들어가지 않으면 어택을 할 수 없다는 식으로

}
