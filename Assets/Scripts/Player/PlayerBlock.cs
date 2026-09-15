using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private InputAction blockAction;
    public bool isBlocking { get; private set; }
    private void Awake()
    {
        if (playerInput != null && playerInput.actions != null)
        {
            blockAction = playerInput.actions["Block"];
            Debug.Log("Assigning block action");
        }
    }    
    private void OnEnable()
    {
        if (playerInput != null && playerInput.actions != null)
        {
            Debug.Log("Enabling block action");
            blockAction.Enable();
            blockAction.started += StartBlocking;
            blockAction.canceled += StopBlocking;
        }
    }
    private void OnDisable()
    {
        if (playerInput != null && playerInput.actions != null)
        {
            Debug.Log("Disabling block action");
            blockAction.Disable();
            blockAction.started -= StartBlocking;
            blockAction.canceled -= StopBlocking;
        }
    }
    private void StartBlocking(InputAction.CallbackContext ctx)
    {
        if (isBlocking) return;
        isBlocking = true;
        Debug.Log("INICIA EL BLOQUEO");
    }
    private void StopBlocking(InputAction.CallbackContext ctx)
    {
        if (!isBlocking) return;
        isBlocking = false;
        Debug.Log("TERMINA EL BLOQUEO");
    }

}
