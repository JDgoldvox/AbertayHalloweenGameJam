using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float sensitivity = 2f;
    [SerializeField] Settings _settings;
    float rotationY = 0.0f;
    float rotationX = 0.0f;
        [SerializeField]
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sensitivity = _settings.sensitivity;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Time.timeScale != 0)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            rotationY -= mouseY;
            rotationY = Mathf.Clamp(rotationY, -80, 80);
            rotationX += mouseX;

            transform.rotation = Quaternion.Euler(new Vector3(rotationY, rotationX, 0));
        }
    }
}
