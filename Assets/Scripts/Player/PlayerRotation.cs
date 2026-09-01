using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    // Update is called once per frame

    public void RotateTowards(Vector3 direction)
    {
        if (direction.sqrMagnitude <= 0) return;

        //calculate rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        //rotate player
        rb.MoveRotation(targetRotation);
    }
}
