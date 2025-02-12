﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameState gameState = GameState.PLAYING;
    public Text timerText;
    public Text enemyCountText;
    public float gameOverTime = 30.0f;
    
    public static GameController instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }else
        {
            instance = this;
        }
    }

    void Update()
    {
        gameOverTime -= Time.unscaledDeltaTime;
        timerText.text = ((int)gameOverTime).ToString() + "s";
        enemyCountText.text = "Enemy Count: " + ProceduralPlacement.instance.GetEnemyCount().ToString();

        if (gameOverTime <= 0.0f)
        {
            GameEnded();
        }
        if (ProceduralPlacement.instance.GetEnemyCount() < 1 && gameState == GameState.PLAYING)
        {
            gameState = GameState.SWITCHING_LEVELS;
            Invoke("NextLvl", 0.5f);
        }
    }

    void NextLvl()
    {
        ProceduralPlacement.instance.GenerateLevel(ProceduralPlacement.instance.CurrentLevel + 1);
    }

    void GameEnded()
    {
        Application.LoadLevel(2);
    }
}

public enum GameState {PLAYING, SWITCHING_LEVELS}
