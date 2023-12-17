using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    [SerializeField] private float _destroyDelayAfterDeath;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Collider _collider;
    [SerializeField] private ParticleSystem _deathVFX;

    private EnemyHealth _enemyHealth;
    private AudioSource _audioSource;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _audioSource = GetComponent<AudioSource>();
        _deathVFX.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _enemyHealth.OnDie += ProcessDeath;
    }

    private void OnDisable()
    {
        _enemyHealth.OnDie -= ProcessDeath;
    }

    private void ProcessDeath()
    {
        _spriteRenderer.enabled = false;
        _collider.enabled = false;
        _deathVFX.gameObject.SetActive(true);
        _audioSource.Play();

        Destroy(gameObject, _destroyDelayAfterDeath);
    }
}
