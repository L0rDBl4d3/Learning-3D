using System;
using Unity.VisualScripting;
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
        Vector3 NormalizedInput = Vector3.Normalize(new Vector3(moveInput.x, 0, moveInput.y));
        Vector3 moveOutput = NormalizedInput * moveSpeed * Time.fixedDeltaTime;

        if(moveInput.sqrMagnitude > 0)
        {
            //calculate rotation
            Quaternion targetRotation = Quaternion.LookRotation(NormalizedInput, Vector3.up);
            //rotate player
            rb.MoveRotation(targetRotation);
        }

        //make player move
        rb.MovePosition(transform.position + moveOutput);

    }
}
