﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Weapons;
using TimeManagement;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        #region PUBLIC_PROPERTIES

        public Text ammoText;
        public float moveSpeed = 5;

        public IWeapon weapon;

        #endregion

        #region  PRIVATE_PROPERTIES

        Vector3 lookDirection;
        Rigidbody rb;
        TimeManager timeManager;
        int raycastLayer; // Created this layer exclusively for raycast

        #endregion

        void Start()
        {
            raycastLayer = LayerMask.GetMask("Raycast");
            timeManager = TimeManager.instance;
            rb = GetComponent<Rigidbody>();
            weapon = GetComponentInChildren<IWeapon>();
            ammoText.text = "Ammo: " + weapon.GetAmmo().ToString();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.Attack(lookDirection);
                ammoText.text = "Ammo: " + weapon.GetAmmo().ToString();
            }
        }

        void FixedUpdate() // Physics update
        {
            // Get inputs
            float xInput = Input.GetAxis("Horizontal");
            float zInput = Input.GetAxis("Vertical");

            // Move player
            Vector3 moveDirection = new Vector3(xInput, 0, zInput).normalized;
            Vector3 moveVelocity = moveDirection * moveSpeed * Time.deltaTime;
            if (moveVelocity.sqrMagnitude > 0)
            {
                timeManager.SetState(TimeState.NORM);
                rb.MovePosition(transform.position + moveVelocity);
            }
            else
            {
                timeManager.SetState(TimeState.SLOW);
            }

            // Get mouse position on screen 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Cast a ray from screen point to the world
            if (Physics.Raycast(ray, out hit, float.PositiveInfinity, raycastLayer))
            {
                // Get where the mouse is pointing in world space
                Vector3 mousePos = hit.point;
                mousePos.y = 1;

                // Get the direction vector from mouse to player
                lookDirection = (mousePos - transform.position).normalized;

                // Rotate player
                transform.LookAt(mousePos);
            }
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.collider.tag == "Ammo")
            {
                Destroy(other.gameObject);
                weapon.SetAmmo(weapon.GetAmmo() + 1);
                ammoText.text = "Ammo: " + weapon.GetAmmo().ToString();
            }
        }

        public void Die()
        {
            print("Homie DED");
            Application.LoadLevel(2);
        }
    }

}
