using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class PumpkinMovement : MonoBehaviour
{
    [SerializeField] private float yDifDown; //amount to displace Y
    [SerializeField] private float yDifUp; //amount to displace Y
    [SerializeField] private float despawnTime;
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
        Destroy(this.gameObject, despawnTime);
    }
    void Start()
    {
        //set start and end positions
        startPos = new Vector3(transform.position.x, transform.position.y - yDifDown, transform.position.z);
        endPos = new Vector3(transform.position.x, transform.position.y + yDifUp, transform.position.z);
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
