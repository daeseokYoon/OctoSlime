using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer99 : MonoBehaviour
{
    public GameObject explo;
   
    void Start()
    {
        
    }

    void Update()
    {
       
    }
    int Attack = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameObject go = Instantiate(explo, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(go, 1);
            GameManager99.instance.SoundExplosion();
            GameManager99.instance.SetGameOver();
        }

        if(collision.gameObject.tag == "Shield")
        {
            GameObject go = Instantiate(explo, transform.position, Quaternion.identity);
            Destroy(go, 1);
            collision.gameObject.GetComponent<Shield99>().Pang(Attack);
            collision.gameObject.GetComponent<Shield99>().ShieldDown();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
