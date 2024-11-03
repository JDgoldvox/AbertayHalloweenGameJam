using Unity.VisualScripting;
using UnityEngine;
using System;

public class XP : MonoBehaviour
{
    private GameObject player;
    public static XP Instance;
    [HideInInspector] public float currentXP = 0;
    [HideInInspector] public float maxXP = 100;
    [HideInInspector] public int levelCount = 0;
    private float additionalHealthOnLevelUp = 0.3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        player = gameObject;
    }

    public void IncreaseXP(float amount)
    {
        currentXP += amount;

        LevelUp();
        UIManager.Instance.SetXPPercentage(currentXP / maxXP);
    }

    private void LevelUp()
    {
        if(currentXP > maxXP)
        {
            float leftOverXP = currentXP - maxXP;
            currentXP = leftOverXP;
            levelCount++;
            maxXP *= 1.1f;

            //inc max health by 10%
            Health healthScript = player.GetComponent<Health>();
            healthScript.maxHealth += 10f;
            //heal by 30%
            healthScript.IncreaseHealth(healthScript.currentHealth + (healthScript.maxHealth * 0.3f)); 

            //generate 3 random modifiers   
            Modifier a = ModifierManager.Instance.ReturnRandomModifier();
            Modifier b = ModifierManager.Instance.ReturnRandomModifier();
            Modifier c = ModifierManager.Instance.ReturnRandomModifier();
            UIManager.Instance.EnableModifierCanvas(a, b, c);
            
            SoundManager.instance.PlaySound(SoundManager.SFX.LEVEL_UP, transform, 1.0f,false);
        }
    }
}
