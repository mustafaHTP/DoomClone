using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpStrength;
    [SerializeField] private Transform _facingDirection;
    [SerializeField] private int _maxJumpCount;

    private Rigidbody _rigidBody;
    private int _jumpCounter = 0;

    //Input
    private Vector2 _moveInput;
    private bool _jumpInput;

    //State
    private bool _isGrounded;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        GetInput();
        Move();
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetJumpCounter();
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void GetInput()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _jumpInput = Input.GetKeyDown(KeyCode.Space);
    }

    private void Jump()
    {
        if (!_jumpInput) return;

        if (_isGrounded)
        {
            ApplyJump();
            ++_jumpCounter;
        }
        else if (!_isGrounded && _jumpCounter < _maxJumpCount)
        {
            ApplyJump();
            ++_jumpCounter;
        }
    }

    private void ApplyJump()
    {
        _rigidBody.velocity = new Vector3(
                        _rigidBody.velocity.x,
                        _jumpStrength,
                        _rigidBody.velocity.z
                    );
    }

    private void Move()
    {
        Vector3 deltaMoveHorizontal = _moveInput.x * _moveSpeed * Time.fixedDeltaTime * _facingDirection.right;
        Vector3 deltaMoveVertical = _moveInput.y * _moveSpeed * Time.fixedDeltaTime * _facingDirection.forward;

        //Dont change Y speed, so keep current speed
        Vector3 currentJumpSpeed = _facingDirection.up * _rigidBody.velocity.y;

        _rigidBody.velocity = deltaMoveHorizontal + deltaMoveVertical + currentJumpSpeed;
    }

    private void ResetJumpCounter() => _jumpCounter = 0;
}
