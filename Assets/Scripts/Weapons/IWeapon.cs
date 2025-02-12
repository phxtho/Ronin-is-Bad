﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        void Attack();

        void Attack(Vector3 direction);

        void Block();

        void SetAmmo(int amount);

        int GetAmmo();
    }

}