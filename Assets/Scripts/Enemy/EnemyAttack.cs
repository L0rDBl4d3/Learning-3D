using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject hitbox;
    [SerializeField] private Animator animator;

    [SerializeField] private float cooldown = 2;
    [SerializeField] private float cooldownTimer;
    [SerializeField]private bool isAttacking;
    private void Attack()
    {
        //set hitbox
        hitbox.GetComponent<Hitbox>().listHurtbox.Clear();
        hitbox.GetComponent<Hitbox>().damage = 20;
        hitbox.SetActive(true);
        //set attack variables
        isAttacking = true;
        animator.SetTrigger("Attack");
        cooldownTimer = cooldown;
    }
    public void AttackEnd()
    {
        //set hitbox
        hitbox.SetActive(false);
        hitbox.GetComponent<Hitbox>().damage = 0;
        hitbox.GetComponent<Hitbox>().listHurtbox.Clear();
        //set attack variables
        isAttacking = false;
    }

    private void FixedUpdate()
    {
        if (!isAttacking && cooldownTimer <= 0) Attack();
        if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;
    }
}
