﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    Transform playerTransform;
    public float moveSpeed = 3f;
    public float rotateSpeed = 100f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();    
    }

    void FixedUpdate() //Fixed update is the physics update
    {
        if(playerTransform != null)
        {
            Vector3 directionToPlayer = (playerTransform.position - this.transform.position).normalized;

            // Look at the player
            Quaternion angularVelocity = Quaternion.Euler(Vector3.up * rotateSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * angularVelocity); // Muliplying quaternions is like adding vectors

            // Move towards the player
            Vector3 moveVelocity = directionToPlayer * moveSpeed * Time.deltaTime;
            if(moveVelocity.sqrMagnitude > 0)
            {
                rb.MovePosition(transform.position + moveVelocity);
            }
        } 
    }
}
