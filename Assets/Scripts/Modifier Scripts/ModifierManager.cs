using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    [SerializeField] private List<Modifier> modifiers;
    public static ModifierManager Instance;
    [SerializeField] private GameObject player;

    float healthIncrease = 20f;
    float movementSpeedMultiplier = 0.05f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public Modifier ReturnRandomModifier()
    {
        int randomIndex = UnityEngine.Random.Range(0, modifiers.Count);
        return modifiers[randomIndex];
    }

    public void AddModifier(string modName)
    {
        switch (modName)
        {
            case "Increase Health":
                player.GetComponent<Health>().InceaseMaxHealth(healthIncrease);
                break;
            case "Increase Movement Speed":
                player.GetComponent<PlayerController>().IncreaseMovementSpeed(movementSpeedMultiplier);
                break;
            case "Increase Projectile Number":
                player.GetComponentInChildren<Weapon>().projectileCount += 2;
                break;
            case "Increase Projectile Fire Rate":
                player.GetComponentInChildren<Weapon>().fireRate += 0.2f;
                break;
            case "Increase Projectile Spread":
                player.GetComponentInChildren<Weapon>().projectileArc += 5;
                break;
            case "Decrease Projectile Spread":
                player.GetComponentInChildren<Weapon>().projectileArc -= 5;
                break;
        }

        Debug.Log("Added new modifier");
    }
}
