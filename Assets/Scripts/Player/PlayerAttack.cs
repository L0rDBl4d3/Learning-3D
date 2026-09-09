using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    [SerializeField] private bool isAttacking;
    [SerializeField] private Animator animator;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        Debug.Log("ATAQUE INICIO");

        animator.SetTrigger("Attack");

        isAttacking = true;
        hitbox.GetComponent<Hitbox>().listHurtbox.Clear();
        hitbox.SetActive(true);

        Debug.Log("HITBOX ACTIVADO");

        yield return new WaitForSeconds(0.1f);
        hitbox.SetActive(false);

        Debug.Log("HITBOX DESACTIVADO");

        isAttacking = false;
    }
}