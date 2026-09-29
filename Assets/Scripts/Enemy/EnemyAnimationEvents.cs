using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    [SerializeField] private EnemyAttack enemyAttack;
    private void OnEndAnimation()
    {
        enemyAttack.AttackEnd();
    }
}
