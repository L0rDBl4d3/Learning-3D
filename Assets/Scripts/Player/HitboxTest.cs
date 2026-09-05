using UnityEngine;

public class HitboxTest : MonoBehaviour
{
    [SerializeField] private GameObject hitbox;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            hitbox.GetComponent<Hitbox>().listHurtbox.Clear();
            hitbox.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            hitbox.SetActive(false);
        }
    }
}
