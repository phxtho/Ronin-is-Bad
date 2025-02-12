﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {

        public int ammo;
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
            if (ammo > 0)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().Fire(direction);
                ammo--;
            }
        }

        public void SetAmmo(int amount)
        {
            ammo = amount;
        }

        public int GetAmmo()
        {
            return ammo;
        }

        public void Block()
        {
        }
    }

}