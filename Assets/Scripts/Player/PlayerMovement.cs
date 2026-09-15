using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerRotation playerRotation;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerInput playerInput;
    private Vector2 moveInput;
    private Vector3 NormalizedInput;
    private Vector3 moveOutput;
    private InputAction moveAction;
    private void Awake()
    {
        if (playerInput != null && playerInput.actions != null)
        {
            moveAction = playerInput.actions["Move"];
        }
    }
    private void OnEnable()
    {
        if (playerInput != null && playerInput.actions != null)
        {
            moveAction.Enable();
        }
    }
    private void OnDisable()
    {
        if (playerInput != null && playerInput.actions != null)
        {
            moveAction.Disable();
        }
    }
    public void OnMove(InputValue value) { 
        //read movement
        moveInput = value.Get<Vector2>();
        NormalizedInput = Vector3.Normalize(new Vector3(moveInput.x, 0, moveInput.y));
        moveOutput = NormalizedInput * moveSpeed * Time.fixedDeltaTime;
    }
    private void FixedUpdate()
    {
        if (moveInput.sqrMagnitude > 0)
        {
            playerRotation.RotateTowards(NormalizedInput);
        }

        if (playerAttack.isAttacking)
        {
            animator.SetBool("isMoving", false);
            return;
        }

        //set isMoving variable in the animator
        bool isMoving = moveInput.sqrMagnitude > 0;

        animator.SetBool("isMoving", isMoving);
        //make player move
        rb.MovePosition(transform.position + moveOutput);
    }

}
