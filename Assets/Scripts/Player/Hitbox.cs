using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public List<Collider> listHurtbox;
    public float damage = 0;
    [SerializeField] private Transform hitboxObject;


    private void Update()
    {
        if(hitboxObject) transform.position = hitboxObject.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        Hurtbox hurtbox = other.GetComponent<Hurtbox>();
        if (hurtbox != null && !listHurtbox.Contains(other))
        {
            listHurtbox.Add(other);
            Debug.Log("entering hurtbox collider");
            other.GetComponentInParent<Health>().TakeDamage(damage);

            //emitir evento OnHit
            hurtbox.TriggerOnHit();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Hurtbox>() != null && listHurtbox.Contains(other))
        {
            listHurtbox.Remove(other);
        }
    }

}
