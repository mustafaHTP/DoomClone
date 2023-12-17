using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
    [SerializeField] private int _healthAmount = 20;
    [SerializeField] private AudioClip _healthPickupClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.IncreaseHealth(_healthAmount);
            AudioSource.PlayClipAtPoint(_healthPickupClip, transform.position);
            Destroy(gameObject);
        }
    }

}
