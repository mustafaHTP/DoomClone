using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public static FPSCamera Instance;

    [SerializeField] private GameObject _playerObject;

    private void Awake()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        transform.SetPositionAndRotation(_playerObject.transform.position, _playerObject.transform.rotation);
    }
}
