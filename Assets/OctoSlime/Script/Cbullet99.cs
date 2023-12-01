using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cbullet99 : MonoBehaviour
{
    public float Speed = 3f;
    public int attack = 50;

    public GameObject explosion;

    Vector2 vec2 = Vector2.down;


    void Start()
    {
        // 그냥 down으로 쓰니까 각 각도로 발사되는 방향으로 down
        // 자폭할 때 넣으면 좋을듯.
    }

    void Update()
    {
        transform.Translate(vec2 * Speed * Time.deltaTime);
    }

    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(go, 1);
            Destroy(collision.gameObject);
            Destroy(gameObject);
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
