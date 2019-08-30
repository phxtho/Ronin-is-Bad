﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public float gameOverTime = 30.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        gameOverTime -= Time.unscaledDeltaTime;

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
