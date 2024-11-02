using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ProjectileType projectileType;
    private float _speed;
    private float _damage;
    private float _despawnTime;
    [SerializeField] private Transform modelTransform;
    
    private Vector3 _direction;
    private GameObject _owner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetType(projectileType);
        Destroy(gameObject, _despawnTime);
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        // Get current position
        Vector3 oldPos = transform.position;
        float distance = _speed / 100.0f;
        
        // Get new desired position
        Vector3 newPos = oldPos + _direction * distance;
        
        // Move to new position
        transform.position = newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If object not owner of projectile
        if (other.gameObject != _owner)
        {
            // Deal damage to enemy
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyBase>().Damage(_damage);
            }
            
            // Delete Projectile Object
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 newDirection)
    {
        // Set direction and normalize
        _direction = newDirection;
        _direction.Normalize();
    }
    
    public void SetOwner(GameObject owner)
    {
        // Track owner to avoid collision with shooter
        this._owner = owner;
    }

    private void SetType(ProjectileType projectileType)
    {
        this.projectileType = projectileType;
        _speed = projectileType.speed;
        _damage = projectileType.damage;
        _despawnTime = projectileType.despawnTime;
        GetComponentInChildren<MeshFilter>().mesh = projectileType.projectileMesh;
        GetComponentInChildren<MeshRenderer>().material = projectileType.projectileMaterial;
    }
}
