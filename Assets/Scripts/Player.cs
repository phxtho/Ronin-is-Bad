﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"),z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x,0,z).normalized;
        movement *= speed;

        transform.position += movement * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
         {
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             RaycastHit hit;
  
             if (Physics.Raycast(ray, out hit))
             {
                 hit.collider.GetComponent<Renderer>().material.color = Color.red;
                 transform.LookAt(hit.point);
                 //Debug.Log(hit);
             }
  
         }
    }
}
