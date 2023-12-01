using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultM99 : MonoBehaviour
{
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<Text>().text = "Coin : " + GameManager99.totalScore.ToString();

        int score = PlayerPrefs.GetInt("score");
        Debug.Log("ÆÄÀÏ°ª  : " + score);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
