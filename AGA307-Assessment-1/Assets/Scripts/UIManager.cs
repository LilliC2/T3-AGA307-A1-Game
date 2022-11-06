using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager>
{
    public TMP_Text gunTypeText;
    public TMP_Text targetCountText;
    public TMP_Text difficultyText;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public Image timerImage;
    float timerChunk = 5;
    float timerMax = 30f;

    // Start is called before the first frame update
    void Start()
    {
        timerImage.fillAmount = 30;
    }

    public void UpdateTimerWheelAdd()
    {
        timerImage.fillAmount += timerChunk;
    }

    public void UpdateTimerWheelRemove(float _timer)
    {
        float fraction = _timer / timerMax;
        timerImage.fillAmount -= fraction/_timer * Time.deltaTime;
    }


    public void UpdateGunType(string _gunType)
    {
        gunTypeText.text = _gunType;
    }

    public void UpdateTargetCount(int _count)
    {
        targetCountText.text = "Targets Left: " + _count;
    }

    public void UpdateDifficulty(Difficulty _difficulty)
    {
        difficultyText.text = "Difficulty: " + _difficulty.ToString();
    }

    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }

    public void TimerUpdate(float _time)
    {
        timerText.text = "Time: " + _time.ToString("F2"); //number of floating point percision
    }
}
