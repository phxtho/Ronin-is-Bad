﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    #region PUBLIC_PROPERTIES

    public float moveSpeed = 5;

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
    }

    void Update()
    {
        // Time Stuff
        if(Input.GetKeyDown(KeyCode.Space) && timeManager != null)
        {
            timeManager.DoSlowMotion();
        }
    }
      
    void FixedUpdate() // Physics update
    {
        // Get inputs
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // Move player
        Vector3 moveDirection = new Vector3(xInput,0,zInput).normalized;
        Vector3 moveVelocity = moveDirection * moveSpeed * Time.deltaTime;
        if(moveVelocity.sqrMagnitude > 0)
        {
            timeManager.SetState(TimeState.NORM);
            rb.MovePosition(transform.position + moveVelocity);
        }else
        {
            timeManager.SetState(TimeState.SLOW);
        }

        // Get mouse position on screen 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Cast a ray from screen point to the world
        if (Physics.Raycast(ray, out hit,float.PositiveInfinity,raycastLayer))
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
}
