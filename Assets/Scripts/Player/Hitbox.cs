using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public List<Collider> listHurtbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
