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
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) //Forward
        {
            direction += camTransform.forward;
        }

        if (Input.GetKey(KeyCode.A)) //Right
        {
            direction += -camTransform.right;
        }

        if (Input.GetKey(KeyCode.D)) //Left
        {
            direction += camTransform.right;
        }

        if (Input.GetKey(KeyCode.S)) //Backwards
        {
            direction += -camTransform.forward;
        }

        rb.AddForce(direction.normalized * speedMultiplier, ForceMode.Impulse);
    }
}
