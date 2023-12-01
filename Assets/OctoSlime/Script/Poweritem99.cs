using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poweritem99 : MonoBehaviour
{
    public float speed = 20.0f;
    Rigidbody2D rb = null; // 안전하게 null 값 부여

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0f), ForceMode2D.Impulse);
        // 한 번만 실행하면 되는 거였는데 무지성으로 업데이트 넣음 멍청한새끼

    }
    
    

    void Update()
    {
       
       
    }
}
