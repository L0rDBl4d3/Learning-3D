using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] Collider hitbox;
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
        if (other.GetComponent<Hurtbox>() != null)
        {
            Debug.Log("entering hurtbox collider");
        }
    }

}
