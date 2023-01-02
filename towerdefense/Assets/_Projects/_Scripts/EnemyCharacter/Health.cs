using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Towerdefense
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _currentHealth;
        public event Action<float> onHealthChanged;
        public void InitHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }
        public void ModifyHealth(float value)
        {
            _currentHealth += value;
            float currentHealth = _currentHealth / _maxHealth;
            onHealthChanged?.Invoke(currentHealth);
        }
    }
}
