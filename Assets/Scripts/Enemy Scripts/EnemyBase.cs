using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected enum STATES
    {
        IDLE,
        CHASE,
        ATTACK
    }

    [SerializeField] protected float maxHealth = 100;
    protected float CurrentHealth = 100;
    [SerializeField] protected float speed = 1;
    [SerializeField] public float damage = 100;
    
    protected STATES CurrentState;
    protected STATES NextState;
    
    private Vector3 _playerDirection;
    protected GameObject Player;
    private Rigidbody _rb;

    //drops
    [SerializeField] private GameObject xpPrefab;
    public float xpDropAmount;

    protected float growlTimer;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        _rb = GetComponent<Rigidbody>();
        
        growlTimer = UnityEngine.Random.Range(2, 10);
    }

    private void Start()
    {
        CurrentHealth = maxHealth;
        
        _playerDirection = Player.transform.position - transform.position;
        
        CurrentState = STATES.IDLE;
        NextState = STATES.IDLE;
        
        int randomInt = UnityEngine.Random.Range(1, 3);

        switch (randomInt)
        {
            case 1:
                SoundManager.instance.PlaySound(SoundManager.SFX.GHOST_SOUND, transform, 0.1f, true);
                break;
            case 2:
                SoundManager.instance.PlaySound(SoundManager.SFX.ZOMBIE_GROWL, transform, 0.1f, true);
                break;
            case 3:
                SoundManager.instance.PlaySound(SoundManager.SFX.PLAGUE_DOCTOR_NOISE, transform, 0.1f, true);
                break;
        }
    }

    private void Update()
    {
        switch (CurrentState)
        {
            // IDLE Logic
            case STATES.IDLE:
                IdleState();
                break;
            
            // CHASE Logic
            case STATES.CHASE:
                ChaseState();
                break;
            
            // ATTACK Logic
            case STATES.ATTACK:
                AttackState();
                break;
            
            default:
                Debug.Log("Oh No, dont get here!");
                break;
        }
        
        CurrentState = NextState;
        
        growlTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        switch (CurrentState)
        {
            // IDLE Logic
            case STATES.IDLE:
                IdlePhysicsState();
                break;
            
            // CHASE Logic
            case STATES.CHASE:
                ChasePhysicsState();
                break;
            
            // ATTACK Logic
            case STATES.ATTACK:
                AttackPhysicsState();
                break;
            
            default:
                Debug.Log("Oh No, dont get here!");
                break;
        }
    }

    protected virtual void IdleState()
    {
        NextState = STATES.CHASE;
    }

    protected virtual void ChaseState() { }
    protected virtual void AttackState() { }
    protected virtual void IdlePhysicsState() { }

    protected virtual void ChasePhysicsState()
    {
        _playerDirection = Player.transform.position - transform.position;
        MoveEnemy(_playerDirection.normalized * speed);
    }
    protected virtual void AttackPhysicsState() { }

    
    private void MoveEnemy(Vector3 velocity)
    {
        _rb.linearVelocity = velocity;
    }
    
    public virtual void Damage(float damageTaken)
    {
        SoundManager.instance.PlaySound(SoundManager.SFX.ENEMY_HIT, transform, 0.5f,true);
        
        CurrentHealth -= damageTaken;

        if (CurrentHealth <= 0)
        {
            Kill();
        }
    }

    protected virtual void Kill()
    {
        SoundManager.instance.PlaySound(SoundManager.SFX.ENEMY_DIE, transform, 1.0f,true);
        
        GameObject newXPPrefab = Instantiate(xpPrefab);
        newXPPrefab.transform.position = transform.position;
        newXPPrefab.GetComponent<xpDrop>().SetXpAmount(xpDropAmount);
        Destroy(gameObject);
    }
}
