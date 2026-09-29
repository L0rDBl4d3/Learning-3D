using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Health health;
    [SerializeField] private float parryWindow;
    [SerializeField] private bool isParrying;
    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownTimer = 0f;
    [SerializeField] private Hurtbox hurtbox;
    private InputAction blockAction;

    public UnityEvent OnParry;
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
            blockAction.started -= StartBlocking;
            blockAction.canceled -= StopBlocking;
            blockAction.Disable();
        }
    }
    private void StartBlocking(InputAction.CallbackContext ctx)
    {
        if (isBlocking || cooldownTimer > 0f) return;

        /**
         * set parry values
         */
        isParrying = true;
        health.isReducedDamage = true;
        health.typeOfReduction = Health.DamageReductionType.Multiplicative;
        health.reductionFactor = 1f;
        Debug.Log("INICIA LA VENTANA DE PARRY");

        StartCoroutine(RunParryTimer());
        isBlocking = true;
    }
    private void StopBlocking(InputAction.CallbackContext ctx)
    {
        if (!isBlocking) return;
        isBlocking = false;
        health.isReducedDamage = false;
        health.typeOfReduction = Health.DamageReductionType.Multiplicative;
        health.reductionFactor = 0f;
        cooldownTimer = cooldown;
        Debug.Log("TERMINA EL BLOQUEO");
    }

    private void FixedUpdate()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    IEnumerator RunParryTimer()
    {
        yield return new WaitForSeconds(parryWindow);
        Debug.Log("TERMINA LA VENTANA DE PARRY");
        /**
         * set blocking values
         */
        if (isBlocking)
        {
            health.isReducedDamage = true;
            health.typeOfReduction = Health.DamageReductionType.Multiplicative;
            health.reductionFactor = 0.5f;
            Debug.Log("INICIA EL BLOQUEO");
        }
    }
    public void RegisterParry()
    {

        if (isParrying)
        {
            Debug.Log("On parry Event");
            OnParry?.Invoke();
        }
    }
}
