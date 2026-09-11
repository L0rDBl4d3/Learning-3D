using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    public bool isAttacking { get; private set; }
    [SerializeField] private Animator animator;
    private bool canCombo = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(!isAttacking) Attack();
            else if (canCombo) Attack();
        } 
    }

    private void Attack()
    {
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