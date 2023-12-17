using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLook : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _facingDirection;
    [SerializeField] private float _rotationSpeed = 50f;
    private float _deltaRotationY;

    private void Update()
    {
        Look();
        ApplyHorizontalRotationToBody();
    }

    private void Look()
    {
        _deltaRotationY = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _rotationSpeed;
        float deltaRotationX = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _rotationSpeed;

        _head.rotation = Quaternion.Euler(
            _head.rotation.eulerAngles.x - deltaRotationX,
            _head.rotation.eulerAngles.y + _deltaRotationY,
            0f
        );
    }

    private void ApplyHorizontalRotationToBody()
    {
        _facingDirection.rotation = Quaternion.Euler(
            0f,
            _facingDirection.rotation.eulerAngles.y + _deltaRotationY,
            0f
        );
    }
}
