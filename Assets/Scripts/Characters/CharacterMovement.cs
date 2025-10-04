using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private InputSystem_Actions inputActions;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    [SerializeField]
    private Collider2D playerBoundary;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        moveDir = inputActions.Player.Move.ReadValue<Vector2>().normalized;
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }

   

}
