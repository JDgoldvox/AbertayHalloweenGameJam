using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Canvas modifierCanvas;
    [SerializeField] private GameObject modifierLeft, modifierMiddle, modifierRight; 

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        modifierCanvas.enabled = true;
    }

    private void Start()
    {
        xpSlider.value = 0;
    }

    public void ChangeHealthPercentage(float percentageChange)
    {
        healthSlider.value += percentageChange;
    }

    public void SetXPPercentage(float percentageChange)
    {
        xpSlider.value = percentageChange;
    }

    public void EnableModifierCanvas(Modifier LeftModifierIn, Modifier middleModifierIn, Modifier rightModifierIn)
    {
        modifierCanvas.enabled = true;

        //set modifier info
        SetModifierInfo(modifierLeft, LeftModifierIn);
        SetModifierInfo(modifierMiddle, middleModifierIn);
        SetModifierInfo(modifierRight, rightModifierIn);
    } 

    private void SetModifierInfo(GameObject modifierTo, Modifier modifierFrom)
    {
        //Modifiers WILL ONLY have 2 children;

        //get modifier text fields
        TMP_Text[] textChildren = modifierTo.GetComponentsInChildren<TMP_Text>();

        //go through all children
        for (int i = 0; i < textChildren.Length; i++)
        {
            if (textChildren[i].name == "ModifierName") //set title
            {
                textChildren[i].text = modifierFrom.modifierName;
            }
            else if(textChildren[i].name == "Description") //set description
            {
                textChildren[i].text = modifierFrom.description;
            }
        }

    }
}
