﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;

public interface IBullet
{
    void Fire(Vector3 direction);
}

public class Bullet : MonoBehaviour, IBullet
{
    public float Damage;
    private float _speed = 60f;
    private Vector3 _direction;
    private Rigidbody _rb;
    private float lifeTime = 5f;

    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
        if(_rb == null)
        {
            this.gameObject.AddComponent(typeof(Rigidbody));
            _rb = this.gameObject.GetComponent<Rigidbody>(); 
        }
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        Vector3 moveVelocity = _direction * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + moveVelocity);   
    }

    public void Fire(Vector3 direction)
    {
        _direction = direction;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        { 
            other.gameObject.GetComponent<EnemyController>().Die();
            Destroy(this.gameObject);
        }
    }
}
