using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poweritem99 : MonoBehaviour
{
    public float speed = 20.0f;
    Rigidbody2D rb = null; // �����ϰ� null �� �ο�

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0f), ForceMode2D.Impulse);
        // �� ���� �����ϸ� �Ǵ� �ſ��µ� ���������� ������Ʈ ���� ��û�ѻ���

    }
    
    

    void Update()
    {
       
       
    }
}
