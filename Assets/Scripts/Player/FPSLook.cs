using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLook : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _facingDirection;
    [SerializeField] private float _lookSensitivity = 50f;

    //It is used to detect move direction
    private float _deltaRotationY;

    private void Update()
    {
        Look();
        SyncHeadRotationToFacingDirection();
    }

    private void Look()
    {
        _deltaRotationY = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _lookSensitivity;
        float deltaRotationX = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _lookSensitivity;

        _head.rotation = Quaternion.Euler(
            _head.rotation.eulerAngles.x - deltaRotationX,
            _head.rotation.eulerAngles.y + _deltaRotationY,
            0f
        );
    }

    private void SyncHeadRotationToFacingDirection()
    {
        _facingDirection.rotation = Quaternion.Euler(
            0f,
            _head.rotation.eulerAngles.y,
            0f
        );
    }
}
