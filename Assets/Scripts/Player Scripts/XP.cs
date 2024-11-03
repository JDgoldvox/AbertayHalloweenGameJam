using Unity.VisualScripting;
using UnityEngine;

public class XP : MonoBehaviour
{
    public static XP Instance;
    private float currentXP = 0;
    private float maxXP = 100;
    public int levelCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = new XP();
        }
    }

    public void IncreaseXP(float amount)
    {
        currentXP += amount;
        LevelUp();
        Debug.Log(currentXP);
        UIManager.Instance.SetXPPercentage(currentXP / maxXP);
    }

    private void LevelUp()
    {
        if(currentXP > maxXP)
        {
            float leftOverXP = currentXP - maxXP;
            currentXP = leftOverXP;
            levelCount++;

            //change health
            UIManager.Instance.ChangeHealthPercentage(0.1f);
        }
    }
}
