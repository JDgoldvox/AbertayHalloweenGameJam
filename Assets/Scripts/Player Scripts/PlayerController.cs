using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    private Rigidbody rb;
    private float speedMultiplier = 0.6f;
    [SerializeField] float jumpMultiplier;
    float jumpTimer = 0;
    float jumpCooldown = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMovement();
        Jump();
    }

    private void UpdateMovement()
    {
        bool isMoving = false;
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) //Forward
        {
            direction += camTransform.forward;
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.A)) //Right
        {
            direction += -camTransform.right;
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.D)) //Left
        {
            direction += camTransform.right;
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.S)) //Backwards
        {
            direction += -camTransform.forward;
            isMoving = true;
        }

        if (isMoving)
        {
            direction.y = 0;
            rb.AddForce(direction.normalized * speedMultiplier, ForceMode.Impulse);
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && jumpTimer <= 0) //jump
        {
            Vector3 direction = Vector3.up + (camTransform.forward * 2);
            direction = direction.normalized;
            direction *= jumpMultiplier;

            rb.AddForce(direction, ForceMode.Impulse);
            jumpTimer = jumpCooldown;
        }
        else
        {
            //update timer
            jumpTimer -= Time.deltaTime;
        }
    }

    public void IncreaseMovementSpeed(float increaseAmount)
    {
        speedMultiplier += increaseAmount;
    }
}
