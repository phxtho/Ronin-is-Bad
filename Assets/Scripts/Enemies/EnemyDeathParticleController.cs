﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
