using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerRotation playerRotation;
    [SerializeField] private Animator animator;
    private PlayerInputActions playerActions;

    private InputAction moveAction;
    private void Awake()
    {
        playerActions = new PlayerInputActions();
        moveAction = playerActions.Player.Move;
    }
    private void OnEnable()
    {
        playerActions.Enable();
    }
    private void OnDisable()
    {
        playerActions.Disable();
    }
    private void FixedUpdate()
    {
        //read movement
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 NormalizedInput = Vector3.Normalize(new Vector3(moveInput.x, 0, moveInput.y));
        Vector3 moveOutput = NormalizedInput * moveSpeed * Time.fixedDeltaTime;

        if(moveInput.sqrMagnitude > 0)
        {
            playerRotation.RotateTowards(NormalizedInput);
        }

        //set isMoving variable in the animator
        bool isMoving = moveInput.sqrMagnitude > 0;
        animator.SetBool("isMoving", isMoving);

        //make player move
        rb.MovePosition(transform.position + moveOutput);


    }
}
