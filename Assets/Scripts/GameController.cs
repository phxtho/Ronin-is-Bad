﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timerText;
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

        if (gameOverTime <= 0.0f)
        {
            GameEnded();
        }
    }

    void GameEnded()
    {
        // Game Over
    }
}
