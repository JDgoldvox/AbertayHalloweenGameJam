using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected enum STATES
    {
        IDLE,
        CHASE,
        ATTACK
    }

    [SerializeField] protected int maxHealth = 100;
    protected int CurrentHealth = 100;
    [SerializeField] protected float speed = 10;
    [SerializeField] protected float damage = 100;
    
    protected STATES CurrentState;
    protected STATES NextState;
    
    protected GameObject Player;
    private Rigidbody _rb;

    private void Start()
    {
        CurrentHealth = maxHealth;

        Player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        
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
    }

    protected virtual void IdleState()
    {
        NextState = STATES.CHASE;
    }

    protected virtual void ChaseState()
    {
        MoveEnemy(Player.transform.position);
    }
    protected virtual void AttackState() { }
    
    private void MoveEnemy(Vector3 velocity)
    {
        _rb.linearVelocity = velocity;
    }
    
    public virtual void Damage(int damageTaken)
    {
        CurrentHealth -= damageTaken;
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}
