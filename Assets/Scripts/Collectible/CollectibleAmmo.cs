using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAmmo : MonoBehaviour, ICollectible
{
    [SerializeField] private int _ammoCount = 10;
    [SerializeField] private AudioClip _ammoPickupClip;

    public void Collect()
    {
        if(!PlayerMovement.Instance.TryGetComponent<AmmoPouch>(out var ammoPouch))
        {
            Debug.LogError("Ammo Pouch Not Found...", gameObject);
            return;
        }

        //If ammo count is full, so don't take ammo
        if (ammoPouch.IsAmmoAmountFull()) return;

        ammoPouch.IncreaseAmmoCount(_ammoCount);
        AudioSource.PlayClipAtPoint(_ammoPickupClip, transform.position);
        Destroy(gameObject);
    }
}
