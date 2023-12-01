using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl99 : MonoBehaviour
{
    public bool isCountDown = true;
    public float gameTime = 0;
    public bool isTimeOver = false;
    public float displayTime = 0;

    float times = 0;

    void Start()
    {
        if (isCountDown)
        {
            displayTime = gameTime; // ó�� ����� �� ���� �ִ�ð��� ǥ�õ� �ð��� �ִ´�.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimeOver == false)
        {
            times += Time.deltaTime;
            if (isCountDown)
            {
                displayTime = gameTime - times;
                if(displayTime <= 0.0f)
                {
                    displayTime = 0.0f;
                    isTimeOver = true;
                }
            }
        }
        else // Ÿ�ӿ����� Ʈ��
        {
            // Ÿ�� ��
            displayTime = times;
            if(displayTime >= gameTime)
            {
                displayTime = gameTime; // �ִ� �ð��� ������ �ΰ� ǥ�õǴ� �ð��� ���� ���� ����.
                isTimeOver = true;
            }
        }
    }
}
