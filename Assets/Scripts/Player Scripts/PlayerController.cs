using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    private Rigidbody rb;
    private float speedMultiplier = 0.5f;
    [SerializeField] float jumpMultiplier;
    float jumpTimer = 0;
    float jumpCooldown = 1;
    private float timer = 0;

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
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = 0.3f;
                int randomInt = UnityEngine.Random.Range(1, 3);

                switch (randomInt)
                {
                    case 1:
                        SoundManager.instance.PlaySound(SoundManager.SFX.PLAYER_FOOTSTEPS_1, transform, 1.0f, false);
                        break;
                    case 2:
                        SoundManager.instance.PlaySound(SoundManager.SFX.PLAYER_FOOTSTEPS_2, transform, 1.0f, false);
                        break;
                    case 3:
                        SoundManager.instance.PlaySound(SoundManager.SFX.PLAYER_FOOTSTEPS_3, transform, 1.0f, false);
                        break;
                }
            }
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
