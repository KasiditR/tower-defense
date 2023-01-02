using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Towerdefense
{
    public interface IDamageable
    {
        event Action onDie;
        void TakeDamage(float damage);
    }
}
