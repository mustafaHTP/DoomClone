using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField] private Transform _gunHolster;

    private List<GameObject> _guns;
    private int _currentGunIndex;

    private void Awake()
    {
        SetupGuns();
    }

    private void Update()
    {
        SwitchGun();
    }

    private void SetupGuns()
    {
        _guns = new();
        for (int i = 0; i < _gunHolster.childCount; i++)
        {
            _guns.Add(_gunHolster.GetChild(i).gameObject);
        }

        //Disable all guns but first gun
        if (_guns.Count > 1)
        {
            _guns.Skip(1).ToList().ForEach(g => g.gameObject.SetActive(false));
        }
    }

    private void SwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsGunSwitchAvailable())
        {
            DisableGun(_currentGunIndex);

            ++_currentGunIndex;
            if (_currentGunIndex == _guns.Count)
            {
                _currentGunIndex = 0;
            }

            EnableGun(_currentGunIndex);
        }
    }

    private void DisableGun(int index)
    {
        _guns[index].gameObject.SetActive(false);
    }

    private void EnableGun(int index)
    {
        _guns[index].gameObject.SetActive(true);
    }

    /// <summary>
    /// If current gun is shooting, block gun switch
    /// </summary>
    /// <returns></returns>
    private bool IsGunSwitchAvailable()
    {
        Gun currentGun = _guns[_currentGunIndex].GetComponent<Gun>();
        if(currentGun != null)
        {
            return !currentGun.IsShooting;
        }
        return false;
    }
}
