using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletVelocity;
    [SerializeField] private int _bulletDamage;

    private Vector3 _direction;
    private Rigidbody _rigidbody;

    public void Init(Vector3 direction)
    {
        _direction = direction;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Inflict damage
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        damagable?.TakeDamage(_bulletDamage);

        Destroy(gameObject);
    }

    private void Move()
    {
        _rigidbody.velocity = _direction * _bulletVelocity * Time.deltaTime;
    }
}
