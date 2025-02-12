﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyController : MonoBehaviour
    {
        Rigidbody rb;
        Transform playerTransform;
        GameObject deathParticles;
        public float moveSpeed = 3f;
        public float rotateSpeed = 100f;
        const int MAX_ENEMY_RADIUS = 400;



        void Start()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            rb = GetComponent<Rigidbody>();
            deathParticles = Resources.Load("Prefabs/EnemyDeathParticles") as GameObject;
        }

        void FixedUpdate() //Fixed update is the physics update
        {
            if (playerTransform != null)
            {
                Vector3 directionToPlayer = (playerTransform.position - this.transform.position).normalized;
                var localTarget = transform.InverseTransformPoint(playerTransform.position);
                var angleToPlayer = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

                // Look at the player
                Quaternion angularVelocity = Quaternion.Euler(Vector3.up * angleToPlayer);
                rb.MoveRotation(rb.rotation * angularVelocity); // Muliplying quaternions is like adding vectors

                // Move towards the player
                Vector3 moveVelocity = directionToPlayer * moveSpeed * Time.deltaTime;
                if (moveVelocity.sqrMagnitude > 0)
                {
                    rb.MovePosition(transform.position + moveVelocity);
                }
            }
        }

        void Update()
        {
            if (transform.position.y > 1)
            {
                transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            }
            if (transform.position.sqrMagnitude > MAX_ENEMY_RADIUS)
            {
                Die();
            }
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<Player.PlayerController>().Die();
            }
        }

        public void Die()
        {
            ProceduralPlacement.instance.RemoveEnemy(this.gameObject);
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }



    }

}