using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaningText99 : MonoBehaviour
{
    [SerializeField]
    float lerpTime = 0.1f;
    TextMeshProUGUI textWaning;

    private void Awake() // 객체 비활성화 상태일때
    {
        textWaning = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() // 객체가 활성화 되면 할 일
    {
        StartCoroutine(ColorLerpLoop());
    }

    IEnumerator ColorLerpLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    IEnumerator ColorLerp(Color first, Color second) // 색 바꾸는 보간 고정 최대값은 1
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            
            // 컬러 럴프 함수 (시작 색, 바뀌는 색, 바뀌는 시간 간격 0~1
            textWaning.color = Color.Lerp(first, second, percent);
            yield return null;
        }
    }

    void Start()
    {
        
    }

     
    void Update()
    {
        
    }
}
