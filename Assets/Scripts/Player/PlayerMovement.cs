using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody rb;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //read movement
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 moveOutput = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        rb.Move(transform.position + moveOutput, transform.rotation);
    }
}
