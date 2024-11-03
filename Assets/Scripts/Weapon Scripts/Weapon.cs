using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    public float fireRate;
    public int projectileCount;
    public float projectileArc;
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
            SoundManager.instance.PlaySound(SoundManager.SFX.WEAPON_SHOOT, transform, 1.0f,false);
            
            float angleInterval = projectileArc / (projectileCount - 1); 
            
            // Calculate direction of each projectile
            for (int i = 0; i < projectileCount; i++)
            {
                transform.position = camTransform.position - new Vector3(0, 0.5f, 0);
                transform.rotation = camTransform.rotation;
                
                transform.Rotate(new Vector3(0, 1, 0), angleInterval * i - projectileArc / 2.0f);
                Vector3 projectileDirection = transform.forward;
                Quaternion projectileRotation = transform.rotation;
                
                Fire(projectileDirection, projectileRotation);
            }
            _fireTimer =  1f / fireRate;
        }
        
        _fireTimer -= Time.deltaTime;
    }

    void Fire(Vector3 direction, Quaternion rotation)
    {
        Projectile projectile = Instantiate(projectilePrefab, transform.position, rotation);
        projectile.SetDirection(direction);
        if (owner) projectile.SetOwner(owner);
    }
}
