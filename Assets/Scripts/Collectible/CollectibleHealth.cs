using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHealth : MonoBehaviour, ICollectible
{
    [SerializeField] private int _healthAmount = 20;
    [SerializeField] private AudioClip _healthPickupClip;

    public void Collect()
    {
        if(!PlayerMovement.Instance.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            Debug.LogError("Player Health Not Found...", gameObject);
            return;
        }

        playerHealth.IncreaseHealth(_healthAmount);
        AudioSource.PlayClipAtPoint(_healthPickupClip, transform.position);
        Destroy(gameObject);
    }
}
