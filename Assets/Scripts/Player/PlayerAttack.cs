using NUnit.Framework.Internal;
using System.Collections;
using Unity.InferenceEngine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float counterAttackWindow;
    [SerializeField] private bool canCounterAttack;
    public bool isAttacking { get; private set; }
    private bool canCombo = false;

    private InputAction attackAction;
    private float attackDamage = 10f;
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
        if (canCounterAttack)
        {
            //do special attack
            //animator.SetTrigger("CounterAttack");
            Debug.Log("CounterAttacking");
        }else
        {

            Debug.Log("ATAQUE INICIO");

            animator.SetTrigger("Attack");
        }
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

        if (state)
        {
            canCombo = state;
            SetDamage(attackDamage);
        }
        else SetDamage(0);
        Debug.Log("HITBOX: " + (state ? "ACTIVO" : "INACTIVO"));
    }
    public void DisableCombo()
    {
        canCombo = false;
    }
    private void SetDamage(float dmg)
    {
        hitbox.GetComponent<Hitbox>().damage = dmg;
    }
    public void ActivateCounterAttack()
    {
        Debug.Log("Contra Ataque Activado");
        canCounterAttack = true;
        StartCoroutine(tres());
    }
    private IEnumerator tres(){ 
        yield return new WaitForSeconds(counterAttackWindow);
        canCounterAttack = false;
    }
}