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
        //���� ü�̽����� ���� �Ÿ� ���� ���� ���ߴ� �� ��� �ϴ���.
    }

    public void Pang(int explosion) // ��ǻ� �Ȱ��� ���� �ΰ��� ���� ����
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
    // Ư�� ������ �����ϸ� �ǵ� ����� // ���� ��ȭ�ϸ� �ǵ嵵 ��ȭ // ���̴� �� ��ŭ �ٲ�� �ǵ��̹���, �ǵ忡�� �迭

    public void ShieldDown()
    {
        player.GetComponent<Player99>().power -= 1;
        if(player.GetComponent<Player99>().power < 0)
        {
            player.GetComponent<Player99>().power = 0;
        }
    }
}
