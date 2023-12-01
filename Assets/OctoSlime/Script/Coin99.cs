using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin99 : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D rb = null;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down;
        
    }
    void Update()
    {
       
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
