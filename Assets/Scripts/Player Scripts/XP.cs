using Unity.VisualScripting;
using UnityEngine;
using System;

public class XP : MonoBehaviour
{
    public static XP Instance;
    private float currentXP = 0;
    private float maxXP = 100;
    public int levelCount = 0;
    private float additionalHealthOnLevelUp = 0.3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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

            //add health when leveling up
            UIManager.Instance.ChangeHealthPercentage(additionalHealthOnLevelUp);

            //generate 3 random modifiers   
            Modifier a = ModifierManager.Instance.ReturnRandomModifier();
            Modifier b = ModifierManager.Instance.ReturnRandomModifier();
            Modifier c = ModifierManager.Instance.ReturnRandomModifier();
            UIManager.Instance.EnableModifierCanvas(a, b, c);
            
            SoundManager.instance.PlaySound(SoundManager.SFX.LEVEL_UP, transform, 1.0f,false);
        }
    }
}
