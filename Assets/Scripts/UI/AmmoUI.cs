using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private AmmoPouch _ammoPouch;
    [SerializeField] private TextMeshProUGUI _ammoCounterTPM;

    private void Update()
    {
        _ammoCounterTPM.text = _ammoPouch.CurrentAmmo.ToString();
    }
}
