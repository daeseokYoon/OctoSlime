using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaningText99 : MonoBehaviour
{
    [SerializeField]
    float lerpTime = 0.1f;
    TextMeshProUGUI textWaning;

    private void Awake() // ��ü ��Ȱ��ȭ �����϶�
    {
        textWaning = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() // ��ü�� Ȱ��ȭ �Ǹ� �� ��
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

    IEnumerator ColorLerp(Color first, Color second) // �� �ٲٴ� ���� ���� �ִ밪�� 1
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            
            // �÷� ���� �Լ� (���� ��, �ٲ�� ��, �ٲ�� �ð� ���� 0~1
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
