using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    private void SetAttackStart()
    {
        Debug.Log("Animacion de ataque inicia");
        playerAttack.StartAttack();
    }
    private void SetAttackEnd()
    {
        Debug.Log("Animacion de ataque termina");
        playerAttack.EndAttack();
    }

    private void EnableHitbox()
    {
        playerAttack.SetHitbox(true);
    }
    private void DisableHitbox()
    {
        playerAttack.SetHitbox(false);
    }
    private void EndAnimation()
    {
        playerAttack.DisableCombo();
    }
}
