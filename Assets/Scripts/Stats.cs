﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI timeScaleTxt, enemySpeedTxt, playerSpeedText;
    public Rigidbody enemyRB, playerRB;

    void Update()
    {
        timeScaleTxt.text = $"TimeScale: {Time.timeScale}";
        enemySpeedTxt.text = (enemyRB == null)? "Enemy Speed: 0 m/s": $"Enemy Speed: {Mathf.Sqrt(enemyRB.velocity.sqrMagnitude)} m/s";
        playerSpeedText.text = $"Player Speed: {Mathf.Sqrt(playerRB.velocity.sqrMagnitude)} m/s";       
    }
}
