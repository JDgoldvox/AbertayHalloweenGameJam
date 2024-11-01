using System;
using Unity.Mathematics;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    enum MODIFIERS
    {
        PROJECTILE_DAMAGE,
        ADDITIONAL_HEALTH,
        MOVEMENT_SPEED_UP
    }


    void Start()
    {
            
    }

    void Update()
    {
        Debug.Log(ReturnRandomModifier());
    }

    private MODIFIERS ReturnRandomModifier()
    {
        //Get Number of elements inside MODIFIERS
        var enumCount = Enum.GetNames(typeof(MODIFIERS)).Length;

        //Get random index with MODIFIER count (min inclusive, max exclusive)
        int randomIndex = UnityEngine.Random.Range(0, enumCount);

        return (MODIFIERS)randomIndex;
    }
}
