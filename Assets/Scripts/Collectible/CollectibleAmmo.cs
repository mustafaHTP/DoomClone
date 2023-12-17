using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAmmo : MonoBehaviour
{
    [SerializeField] private int _ammoCount = 10;
    [SerializeField] private AudioClip _ammoPickupClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out AmmoPouch ammoPouch))
        {
            ammoPouch.IncreaseAmmoCount(_ammoCount);
            AudioSource.PlayClipAtPoint(_ammoPickupClip, transform.position);
            Destroy(gameObject);
        }
    }
}
