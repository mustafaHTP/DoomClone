using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    public event Action OnDie;

    private const int MinHealth = 0;

    [SerializeField] private int _maxHealth = 10;

    private int _currentHealth;

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        _currentHealth = Mathf.Max(MinHealth, _currentHealth);

        if(_currentHealth == MinHealth)
        {
            Die();
        }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Die()
    {
        OnDie?.Invoke();
    }
}
