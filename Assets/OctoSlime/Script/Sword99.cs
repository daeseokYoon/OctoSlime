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
    // ���� ��ȭ // �ֵθ����� ������ ���Բ� ���� �ʿ� 
    // bool ���̶� ���ǹ����� ��� ���������� zx ��ư�� true�� ���� ������ ������ �� �� ���ٴ� ������

}
