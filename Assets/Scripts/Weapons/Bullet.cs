﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    public void Fire(Vector3 direction);
}

public class Bullet : MonoBehaviour, IBullet
{
    public float Damage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Fire(Vector3 direction)
    {
        
    }

    void OnCollisionEnter()
    {

    }
}
