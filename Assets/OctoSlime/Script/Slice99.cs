using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice99 : MonoBehaviour
{
    public float attack = 100;
    public GameObject attacked;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            GameObject go = Instantiate(attacked, collision.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject go = Instantiate(attacked, collision.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Boss")
        {
            GameObject go = Instantiate(attacked, collision.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            collision.gameObject.GetComponent<Mboss99>().GetDamage(attack);
        }
    }
}