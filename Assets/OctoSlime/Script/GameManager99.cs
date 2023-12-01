using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager99 : MonoBehaviour
{
    public static GameManager99 instance;
    public Text killScore;
    public Text coinCnt;
    public GameObject gameover;
    public GameObject gameclear;
    int score = 0;
    int coin = 0;

    public GameObject timeText;
    TimeControl99 timeCnt;

    AudioSource myAudio;
    public AudioClip soundDie;
    public AudioClip soundExplosion;

    public GameObject Coin2;

    public static int totalScore;  //���� ����

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        timeCnt = GetComponent<TimeControl99>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f) // ������Ʈ�� ���� ��ü �ð��� 0�̸�
            {
                timeText.SetActive(false);
            }
        }

        myAudio = GetComponent<AudioSource>();

        UpdateScore();

        PlayerPrefs.SetInt("score", 0);

    }

    private void UpdateScore()
    {
        int score = coin;
        coinCnt.GetComponent<Text>().text = "Coin : " + score.ToString();
    }

    public void SoundDie()
    {
        myAudio.PlayOneShot(soundDie);
    }
    public void SoundExplosion()
    {
        myAudio.PlayOneShot(soundExplosion);
    }

    public void AddScore(int num) // UI ���ھ� ������ �׳� �̱������� ���� �ɵ�
    {
        score += num; 
        killScore.text = "Kill score : " + score;
    }

    public void AddCoin(int num)
    {
        coin += num;
        coinCnt.text = "Coin cnt : " + coin;
    }

    public void SetGameOver()
    {
        Time.timeScale = 0;
        gameover.SetActive(true);
        if (timeCnt != null)
        {
            timeCnt.isTimeOver = true;
        }
    }

    public void SetGameClear()
    {
        Time.timeScale = 0;
        gameclear.SetActive(true);
        if (timeCnt != null) // ī��Ʈ�� �����־ Ÿ�ӿ��� ����
        {
            timeCnt.isTimeOver = true;
        }
    }

    //public void CoinPang()
    //{
    //    if (player.GetComponent<Player99>().CoinCnt >= 1)
    //    {
    //        for (int i = 0;  i < player.GetComponent<Player99>().CoinCnt; i++)
    //        {
    //            Instantiate(Coin2, player.transform.position, Quaternion.identity);
    //        }
    //        player.GetComponent<Player99>().CoinCnt -= player.GetComponent<Player99>().CoinCnt;
    //        AddCoin(0);
    //    }
    //    else if(player.GetComponent<Player99>().CoinCnt == 0)
    //    {
    //        Destroy(player);
    //        SetGameOver();
    //        SoundExplosion();
    //    }
    //}

    void Update()
    {
        if(timeCnt.gameTime > 0.0f)
        {
            int time = (int)timeCnt.displayTime;
            timeText.GetComponent<Text>().text = time.ToString();
            if(time == 0)
            {
                SetGameOver();
            }
        }

        //���� �߰�
        totalScore += coin;
       
        UpdateScore(); //��������
    }
}
