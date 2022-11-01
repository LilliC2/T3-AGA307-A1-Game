using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Title, Paused, Playing, GameOver }
public enum Difficulty { Easy, Medium, Hard }

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public Difficulty difficulty;

    public int score;
    int scoreMultipler = 1;

    private void Start()
    {
        SetUp();

        
    }

    private void Update()
    {
        //temp
        if (Input.GetKeyDown(KeyCode.Keypad1)) difficulty = Difficulty.Easy;
        if (Input.GetKeyDown(KeyCode.Keypad2)) difficulty = Difficulty.Medium;
        if (Input.GetKeyDown(KeyCode.Keypad3)) difficulty = Difficulty.Hard;
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
    }

}
