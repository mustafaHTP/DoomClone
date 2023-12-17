using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private TextMeshProUGUI _healthAmountTMP;

    private void Update()
    {
        float normalizedHealth = ((float)_playerHealth.CurrentHealth / _playerHealth.MaxHealth) * 100;
        _healthAmountTMP.text = $"%{normalizedHealth}";
    }
}
