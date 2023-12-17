using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private event Action OnShoot;

    [Header("Ammo Config")]
    [SerializeField] private AmmoPouch _ammoPouch;

    [Header("Shoot Config")]
    [SerializeField] private float _shootCooldown = 2f;

    [Header("Bullet Config")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;

    private bool _isShooting;

    private Animator _animator;
    private AudioSource _audioSource;

    public bool IsShooting => _isShooting;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        OnShoot += PlayShootAnimation;
        OnShoot += PlayShootSFX;
        OnShoot += SpawnBullet;
    }

    private void OnDisable()
    {
        OnShoot -= PlayShootAnimation;
        OnShoot -= PlayShootSFX;
        OnShoot -= SpawnBullet;
    }

    private void Update()
    {
        Shoot();
    }

    private void PlayShootAnimation()
    {
        _animator.SetTrigger("shoot");
    }

    private void PlayShootSFX(){
        _audioSource.Play();
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && _ammoPouch.HasEnoughAmmo() && !_isShooting)
        {
            StartCoroutine(ShootCoroutine());
        }
    }

    private IEnumerator ShootCoroutine()
    {
        _isShooting = true;

        _ammoPouch.ReduceAmmoCount();
        OnShoot?.Invoke();

        yield return new WaitForSeconds(_shootCooldown);

        _isShooting = false;
    }

    private void SpawnBullet()
    {
        GameObject bulletInstance = Instantiate(
            _bulletPrefab,
            _bulletSpawnPoint.position,
            Quaternion.identity);

        if (bulletInstance.TryGetComponent(out Bullet bullet))
        {
            Vector3 bulletDirection = (_bulletSpawnPoint.forward).normalized;
            bullet.Init(bulletDirection);
        }
    }
}
