using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth;

    private const int MinHealth = 0;
    private event Action OnDie;
    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        _currentHealth = Mathf.Max(MinHealth, _currentHealth);
        Debug.Log("Player take damage, health: " + _currentHealth);
        if (_currentHealth == MinHealth)
        {
            Die();
        }
    }

    public bool HasMaxHealth() => _currentHealth == _maxHealth;

    public void IncreaseHealth(int healthAmount)
    {
        _currentHealth += healthAmount;
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
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
