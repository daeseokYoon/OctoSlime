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
            displayTime = gameTime; // 처음 실행될 때 넣을 최대시간을 표시될 시간에 넣는다.
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
        else // 타임오버가 트루
        {
            // 타임 업
            displayTime = times;
            if(displayTime >= gameTime)
            {
                displayTime = gameTime; // 최대 시간을 지정해 두고 표시되는 시간을 따로 쓰는 이유.
                isTimeOver = true;
            }
        }
    }
}
