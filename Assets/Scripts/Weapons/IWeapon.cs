﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Attack();

    void Attack(Vector3 direction);

    void Block();
}
