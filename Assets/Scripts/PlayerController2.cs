using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController2 : MonoBehaviour
{

    [Header("Settings")]

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    [Header("Components")]

    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private bool _lookRight;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(Input.acceleration.x * _moveSpeed, _rigidbody.velocity.y);

        CheckFlip();
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
    public void BounceJump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce * 2f);
    }

    private void CheckFlip()
    {
        if (Input.acceleration.x > 0 && !_lookRight)
        {
            Flip();
        }
        else if (Input.acceleration.x < 0 && _lookRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        _lookRight = !_lookRight;
    }

}
