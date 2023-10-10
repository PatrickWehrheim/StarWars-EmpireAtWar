using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnowPlayer : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    private Vector2 _movement;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();    
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _characterController.Move(new Vector3(_movement.x, 0, _movement.y));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        _movement = move * _moveSpeed * Time.deltaTime;
    }
}
