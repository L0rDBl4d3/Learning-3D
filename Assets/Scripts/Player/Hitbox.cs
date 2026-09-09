using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public List<Collider> listHurtbox;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hurtbox>() != null && !listHurtbox.Contains(other))
        {
            listHurtbox.Add(other);
            Debug.Log("entering hurtbox collider");
            other.GetComponentInParent<Health>().TakeDamage(10);
        }
    }

}
