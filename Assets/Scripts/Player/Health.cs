using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("perdiste: " + damage + " de hp, te quedan " + health + ".");
    }
}
