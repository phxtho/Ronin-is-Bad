﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    int raycastLayer;// Created this layer exclusively for raycasts
    void Awake()
    {
        raycastLayer = LayerMask.GetMask("Raycast"); 
    }
      
    void Update()
    {
        // Movement Stuff
        float x = Input.GetAxis("Horizontal"),z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x,0,z).normalized;
        movement *= moveSpeed;

        transform.position += movement * Time.deltaTime;

        // Look Stuff 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,float.PositiveInfinity,raycastLayer))
        {
            Vector3 lookPos = hit.point;
            lookPos.y = 1;  
            transform.LookAt(lookPos);
        }

    
    }
}
