using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPouch : MonoBehaviour
{
    [SerializeField] private int _maxAmmoAmount;

    private const int MinAmmoAmount = 0;
    private int _currentAmmo;

    public int CurrentAmmo => _currentAmmo;

    public bool HasEnoughAmmo() => _currentAmmo > 0;

    public bool IsAmmoAmountFull() => _currentAmmo == _maxAmmoAmount;

    public void ReduceAmmoCount()
    {
        --_currentAmmo;
        _currentAmmo = Mathf.Max(MinAmmoAmount, _currentAmmo); 
    }

    public void IncreaseAmmoCount(int ammoAmount)
    {
        _currentAmmo += ammoAmount;
        _currentAmmo = Mathf.Min(_currentAmmo, _maxAmmoAmount);
    }

    private void Awake()
    {
        _currentAmmo = _maxAmmoAmount;
    }
}
