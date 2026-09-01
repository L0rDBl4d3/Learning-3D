using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 _position = new Vector3(0,3,-5);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        _camera.transform.position = player.transform.position + _position;
        _camera.transform.LookAt(player.transform.position);
    }
}
