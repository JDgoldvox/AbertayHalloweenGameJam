using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject owner;
    [SerializeField] private Transform camTransform;
    private float _fireTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _fireTimer = 1f / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && _fireTimer <= 0)
        {
            Fire(camTransform.forward);
            _fireTimer =  1f / fireRate;
        }
        
        _fireTimer -= Time.deltaTime;
    }

    void Fire(Vector3 direction)
    {
        Projectile projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.SetDirection(direction);
        if (owner) projectile.SetOwner(owner);
    }
}
