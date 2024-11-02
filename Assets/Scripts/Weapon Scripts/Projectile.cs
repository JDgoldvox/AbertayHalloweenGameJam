using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ProjectileType projectileType;
    private float _speed;
    private float _damage;
    private float _despawnTime;
    private Vector3 _rotation;
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
        RaycastHit[] hits;
        
        // Raycast along travel path
        hits = Physics.RaycastAll(oldPos, newPos);
        foreach (RaycastHit hit in hits)
        {
            // Don't hit the player that shot the bullet
            if (hit.collider.gameObject != _owner.gameObject)
            {
                //Destroy(gameObject);

                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    // Damage Enemy
                    hit.collider.gameObject.GetComponent<EnemyBase>().Damage(_damage);
                }

                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    // Damage Player
                }
                
                break;
            }
        }
        
        // Move to new position
        transform.position = newPos;
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

    public void SetType(ProjectileType projectileType)
    {
        this.projectileType = projectileType;
        _speed = projectileType.speed;
        _damage = projectileType.damage;
        _despawnTime = projectileType.despawnTime;
        _rotation = projectileType.rotation;
        GetComponentInChildren<MeshFilter>().mesh = projectileType.projectileMesh;
        GetComponentInChildren<MeshRenderer>().material = projectileType.projectileMaterial;
    }
}
