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
    [SerializeField] protected float damage = 100;
    
    protected STATES CurrentState;
    protected STATES NextState;
    
    private Vector3 _playerDirection;
    protected GameObject Player;
    private Rigidbody _rb;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        CurrentHealth = maxHealth;
        
        _playerDirection = Player.transform.position - transform.position;
        
        CurrentState = STATES.IDLE;
        NextState = STATES.IDLE;
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
        CurrentHealth -= damageTaken;

        if (CurrentHealth <= 0)
        {
            Kill();
        }
    }

    protected virtual void Kill()
    {
        Destroy(gameObject);
    }
}
