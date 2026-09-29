using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHitboxMovement : MonoBehaviour
{
    [SerializeField] Transform center;
    [SerializeField] float radio;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    private float total=0;

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = radio * math.cos(total * speed);
        float z = radio * math.sin(total * speed);
        rb.MovePosition(center.position + new Vector3(x,0,z));
        total += Time.deltaTime;
        //Debug.Log("x: " + x);
        //Debug.Log("z: " + z);
        //Debug.Log("transform.position: " + transform.position);
    }
}
