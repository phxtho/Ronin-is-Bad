﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timerText;
    public Text enemyCountText;
    public float gameOverTime = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        // timerText.text = gameOverTime.ToString();
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
        if (ProceduralPlacement.instance.GetEnemyCount() < 1)
        {
            ProceduralPlacement.instance.GenerateLevel(ProceduralPlacement.instance.CurrentLevel + 1);
        }
    }

    void GameEnded()
    {
        Application.LoadLevel(2);
    }
}
