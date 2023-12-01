using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin299 : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int X = Random.Range(-1, 1);
        Vector2 vec2 = new Vector2(X, 1);
        rb.velocity = vec2;
        rb.AddForce(vec2 * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
