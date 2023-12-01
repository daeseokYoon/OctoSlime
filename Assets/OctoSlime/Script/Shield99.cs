using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield99 : MonoBehaviour
{
    public int Defend = 100;

    GameObject player;

    void Start()
    {       
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = player.transform.position.z;

        Vector3 vector3 = new Vector3(x, y, z);
        transform.position = vector3;
    }

    void FixedUpdate()
    {
        //몬스터 체이스에서 일정 거리 까지 오면 멈추는 것 어떻게 하더라.
    }

    public void Pang(int explosion) // 사실상 똑같은 것을 두개나 썻네 ㄷㄷ
    {
        Defend -= explosion;
        if (Defend <= 0)
            Destroy(gameObject);
        GameManager99.instance.SoundExplosion();
    }

    public void GetDamage(int attack)
    {
        Defend -= attack;
        if (Defend <= 0)
            Destroy(gameObject);
        GameManager99.instance.SoundExplosion();
    }
    // 특정 조건을 만족하면 실드 재생성 // 무기 강화하면 실드도 강화 // 꺾이는 방어량 만큼 바뀌는 실드이미지, 실드에도 배열

    public void ShieldDown()
    {
        player.GetComponent<Player99>().power -= 1;
        if(player.GetComponent<Player99>().power < 0)
        {
            player.GetComponent<Player99>().power = 0;
        }
    }
}
