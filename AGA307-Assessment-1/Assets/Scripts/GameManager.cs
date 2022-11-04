using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Title, Paused, Playing, GameOver }
public enum Difficulty { Easy, Medium, Hard }

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    public Difficulty difficulty;

    float timer = 30f;
    float bonusTime = 5;

    UIManager _UI;


    public int score;
    int scoreMultipler = 1;

    private void Start()
    {
        _UI = FindObjectOfType<UIManager>();
        SetUp();

        
    }

    private void Update()
    {
        if (gameState == GameState.Playing)
        {
            timer -= Time.deltaTime;
            _UI.TimerUpdate(timer);

        }

        //temp
        if (Input.GetKeyDown(KeyCode.Keypad1)) difficulty = Difficulty.Easy;
        if (Input.GetKeyDown(KeyCode.Keypad2)) difficulty = Difficulty.Medium;
        if (Input.GetKeyDown(KeyCode.Keypad3)) difficulty = Difficulty.Hard;
        if (gameState == GameState.Playing) _UI.UpdateDifficulty(difficulty);
    }
    
    public void ScoreCalcuation(int _score)
    {
        score = _score * scoreMultipler;

        if(gameState == GameState.Playing) _UI.UpdateScore(score);
    }

    public void AddToTimer()
    {
        print("5 SECONDS ADDED");
        timer += bonusTime;
    }

    void SetUp()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultipler = 1;
                break;
            case Difficulty.Medium:
                scoreMultipler = 2;
                break;
            case Difficulty.Hard:
                scoreMultipler = 3;
                break;
        }

        if (gameState == GameState.Playing) _UI.UpdateDifficulty(difficulty);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeDifficulty(int _difficulty)
    {
        difficulty = (Difficulty)_difficulty;
        SetUp();
    }

}
