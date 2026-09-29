using UnityEngine;

public class TestAttack : MonoBehaviour
{
    // SIRVE PARA QUE PLAYER RECIBA DAÑO PARA PROBAR EL BLOQUEO, A PARTIR DEL INPUTMAP TESTATTACK, NADA MAS
    private void OnTestAttack()
    {
        Debug.Log("RECIBIENDO DAÑO, DAÑO BRUTO = 10");
        transform.GetComponentInParent<Health>().TakeDamage(10);
    }
}
