using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    [SerializeField] private Transform camTransform;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = camTransform.position + camTransform.forward - camTransform.up * 0.75f;
        transform.rotation = camTransform.rotation;
    }
}
