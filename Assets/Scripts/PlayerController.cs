using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _speed = _rb.linearVelocity.magnitude;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(camTransform.forward * 3f, ForceMode.VelocityChange);
        }
        else
        {
            _rb.linearVelocity = Vector3.zero;
        }
    }
}
