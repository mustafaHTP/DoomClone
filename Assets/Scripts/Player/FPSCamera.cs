using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public static FPSCamera Instance;

    [SerializeField] private Transform _fpsCameraHolder;

    private void Awake()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        transform.SetPositionAndRotation(_fpsCameraHolder.position, _fpsCameraHolder.rotation);
    }
}
