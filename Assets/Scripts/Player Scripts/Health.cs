using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance;

    [SerializeField] float maxHealth = 100f;
    public float currentHealth = 100f;
    [SerializeField] float invulnerabilityTime = 0.5f;
    private float _invulnerabilityTimer = 0f;
    private float _heartbeatTimer;

    private void Awake()
    {
        currentHealth = maxHealth;
        _invulnerabilityTimer = 0;

        if(Instance != null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            GameOver();
        }
        
        _invulnerabilityTimer -= Time.deltaTime;
        
        _heartbeatTimer -= Time.deltaTime;
        
        if (_heartbeatTimer <= 0)
        {
            if (currentHealth > 66)
            {
                SoundManager.instance.PlaySound(SoundManager.SFX.HEARTBEAT_SLOW, transform, 1.0f, false);
                _heartbeatTimer = 3;
            }
            else if (currentHealth < 33)
            {
                SoundManager.instance.PlaySound(SoundManager.SFX.HEARTBEAT_FAST, transform, 1.0f, false);
                _heartbeatTimer = 1;
            }
            else
            {
                SoundManager.instance.PlaySound(SoundManager.SFX.HEARTBEAT_MID, transform, 1.0f, false);
                _heartbeatTimer = 2;
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (_invulnerabilityTimer <= 0)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                float damage = other.gameObject.GetComponent<EnemyBase>().damage;
                currentHealth -= damage;

                float percentage = damage / maxHealth;

                // Take damage
                UIManager.Instance.ChangeHealthPercentage(-percentage);
                int randomInt = UnityEngine.Random.Range(1, 3);

                switch (randomInt)
                {
                    case 1:
                        SoundManager.instance.PlaySound(SoundManager.SFX.PLAYER_HIT_1, transform, 1.0f,false);
                        break;
                    case 2:
                        SoundManager.instance.PlaySound(SoundManager.SFX.PLAYER_HIT_2, transform, 1.0f,false);
                        break;
                    case 3:
                        SoundManager.instance.PlaySound(SoundManager.SFX.PLAYER_HIT_3, transform, 1.0f,false);
                        break;
                }

                _invulnerabilityTimer = invulnerabilityTime;
            }
        }
    }

    public void InceaseMaxHealth(float healthIncreaseModifier)
    {
        maxHealth += healthIncreaseModifier;
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
