using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nBullet99 : MonoBehaviour
{
    public float Speed = 3f;
    public int attack = 50;

    public GameObject explosion;

    Vector2 vec2 = Vector2.down;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(vec2 * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 1);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager99.instance.SetGameOver();
            GameManager99.instance.SoundExplosion();
        }
        if (collision.gameObject.tag == "Shield")
        {
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 1);
            collision.gameObject.GetComponent<Shield99>().Pang(attack);
            collision.gameObject.GetComponent<Shield99>().ShieldDown();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
