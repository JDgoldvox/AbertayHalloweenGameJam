using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance;

    [SerializeField] float maxHealth = 100f;
    public float currentHealth = 100f;
    [SerializeField] float invulnerabilityTime = 0.5f;
    private float _invulnerabilityTimer = 0f;

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
                Debug.Log(percentage);

                // Take damage
                UIManager.Instance.ChangeHealthPercentage(-percentage);

                _invulnerabilityTimer = invulnerabilityTime;
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
