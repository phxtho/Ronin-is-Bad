﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeManagement
{
    public enum TimeState { SLOW, NORM, FAST}

    public class TimeManager : MonoBehaviour
    {
        public static TimeManager instance; // Singleton

        const float MIN_TIME_SCALE = 0.05f;
        const float MAX_TIME_SCALE = 1f;

        float slowdownFactor = 0.05f;
        float speedUpTime = 0.5f;   // the number of seconds it takes to spped up to MAX_TIME_SCALE
        float slowDownTime = 0.25f; // the number of seconds it takes to  slow down to MIN_TIME_SCALE

        TimeState timeState = TimeState.SLOW;

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
            switch(timeState){
                case TimeState.SLOW:
                    float tScale = Time.timeScale - (1f/slowDownTime) * Time.unscaledDeltaTime;
                    tScale = Mathf.Clamp(tScale, MIN_TIME_SCALE, MAX_TIME_SCALE);   
                    Time.timeScale = tScale;
                    Time.fixedDeltaTime = Time.timeScale * 0.02f; 
                    break;
                
                case TimeState.NORM:
                    Time.timeScale += (1f/speedUpTime) * Time.unscaledDeltaTime;
                    Time.timeScale = Mathf.Clamp(Time.timeScale, MIN_TIME_SCALE, MAX_TIME_SCALE);
                    Time.fixedDeltaTime = Time.timeScale * 0.02f; 
                    break;
            }
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

        public void SetState(TimeState state)
        {
            timeState = state;
        }
    }
}
