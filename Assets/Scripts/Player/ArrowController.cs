﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;
using TimeManagement;

namespace Player 
{
public class ArrowController : MonoBehaviour
{   
    #region PUBLIC_PROPERTIES
        public Transform player;
        

    #endregion

    // Start is called before the first frame update
    void Start()
        {
            
        }
    // Update is called once per frame
    void Update()
    {   transform.position=player.position;
        transform.Translate(0,(float)(-1),1,player);
        transform.rotation=player.rotation;
        transform.Rotate(0,90,90);

    }
}
}
