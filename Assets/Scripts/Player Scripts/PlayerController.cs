using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    
    private Rigidbody _rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // TEMPORARY INPUT MANAGEMENT
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
