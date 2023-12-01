using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebullet99 : MonoBehaviour
{
    public float speed = 1f;
    public int attack = 50;
    GameObject player;
    public GameObject explosion;

    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            dir = player.transform.position - transform.position;
            dirNo = dir.normalized;
        }
        else
        {
            dirNo = Vector2.down;
        }
    }


    void Update()
    {
        transform.Translate(dirNo * speed * Time.deltaTime);
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
