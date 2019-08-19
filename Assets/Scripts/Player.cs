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
    }
}
