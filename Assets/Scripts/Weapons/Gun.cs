﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {
        public GameObject bulletPrefab;

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        public void Attack()
        {
        }

        public void Attack(Vector3 direction)
        {
            GameObject bullet = Instantiate(bulletPrefab,transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Fire(direction);
        }

        public void Block()
        {
        }
    }

}