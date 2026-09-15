using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInput playerInput;
    public bool isAttacking { get; private set; }
    private bool canCombo = false;

    private InputAction attackAction;

    private void Awake()
    {
        if (playerInput != null && playerInput.actions != null)
        {
            attackAction = playerInput.actions["Attack"];
            Debug.Log("Assigning attack action");
        }
    }

    private void OnEnable()
    {
        if (playerInput != null && playerInput.actions != null)
        {
            attackAction.Enable();
            attackAction.started += Attack;
        }
    }
    private void OnDisable()
    {
        if (playerInput != null && playerInput.actions != null)
        {
            attackAction.Disable();
            attackAction.started -= Attack;
        }
    }

    private void Attack(InputAction.CallbackContext ctx)
    {
        if (isAttacking && !canCombo) return;
        Debug.Log("ATAQUE INICIO");

        animator.SetTrigger("Attack");
    }

    public void StartAttack()
    {
        isAttacking = true;
        hitbox.GetComponent<Hitbox>().listHurtbox.Clear();
        hitbox.SetActive(false);
    }
    public void EndAttack()
    {
        isAttacking = false;
    }

    public void SetHitbox(bool state)
    {
        hitbox.SetActive(state);

        if(state) canCombo = state;

        Debug.Log("HITBOX: "+ (state ? "ACTIVO" : "INACTIVO"));
    }
    public void DisableCombo()
    {
        canCombo = false;   
    }
}