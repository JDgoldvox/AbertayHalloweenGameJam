using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class PumpkinMovement : MonoBehaviour
{
    [SerializeField] private float yDif; //amount to displace Y to -Y
    private Transform transform;
    private float upDownTimer = 0;
    private float maxUpDownTime = 2;
    private float rotateSpeed = 120;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isUp = true;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }
    void Start()
    {
        //set start and end positions
        startPos = new Vector3(transform.position.x, transform.position.y - yDif, transform.position.z);
        endPos = new Vector3(transform.position.x, transform.position.y + yDif, transform.position.z);
    }

    void Update()
    {
        UpAndDownMovement();
        RotateRight();
    }

    void UpAndDownMovement()
    {
        if (isUp)
        {
            upDownTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, endPos, upDownTimer / maxUpDownTime);

            if (upDownTimer >= maxUpDownTime)
            {
                isUp = false;
                upDownTimer = 0;
            }
        }
        else
        {
            upDownTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(endPos, startPos, upDownTimer / maxUpDownTime);

            if (upDownTimer >= maxUpDownTime)
            {
                isUp = true;
                upDownTimer = 0;
            }
        }
    }

    void RotateRight()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
