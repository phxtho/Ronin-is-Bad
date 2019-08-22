﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance; // Singleton
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    void Awake()
    {
        // Ensure theres only ever one instance of time manager
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    void Update()
    {
        Time.timeScale += (1f/slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
    }

    public void DoSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;    
    }

    public void SetTimeScale(float timeFactor)
    {
        Time.timeScale = timeFactor;
        Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
    }
}
