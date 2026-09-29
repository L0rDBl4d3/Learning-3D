using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100;

    public bool isReducedDamage;
    public float reductionFactor;
    public DamageReductionType typeOfReduction;
    public enum DamageReductionType
    {
        Multiplicative,
        Flat
    }
    public void TakeDamage(float damage)
    {
        if (isReducedDamage) damage = reduceDamage(reductionFactor, damage, typeOfReduction);
        health -= damage;
        Debug.Log(gameObject.name+":"+" perdiste: " + damage + " de hp, te quedan " + health + ".");
        if (health <= 0) Death();
    }

    public float reduceDamage(float reduction, float damage, DamageReductionType type = DamageReductionType.Multiplicative)
    {
        if(type == DamageReductionType.Multiplicative)
        {
            return damage * (1- reduction);
        }
        else
        {
            return damage - reduction;
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
