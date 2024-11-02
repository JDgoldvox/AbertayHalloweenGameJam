using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    private Rigidbody rb;
    private float speedMultiplier = 1.5f;

    [SerializeField] private float linearVelocityCap;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(camTransform.forward * speedMultiplier, ForceMode.Impulse);
        }

    }
}
