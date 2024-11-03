using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Canvas modifierCanvas;
    [SerializeField] private GameObject modifierLeft, modifierMiddle, modifierRight; 
    public string modifierLeftName, modifierMiddleName, modifierRightName;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        xpSlider.value = 0;
    }

    public void SetXPPercentage(float percentageChange)
    {
        xpSlider.value = percentageChange;
    }

    public void ChangeHealthPercentage(float percentageChange)
    {
        healthSlider.value += percentageChange;
    }

    public void EnableModifierCanvas(Modifier LeftModifierIn, Modifier middleModifierIn, Modifier rightModifierIn)
    {
        modifierCanvas.gameObject.SetActive(true);
        Debug.Log("enabling canvas");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //set modifier info
        modifierLeftName = SetModifierInfo(modifierLeft, LeftModifierIn);
        modifierMiddleName = SetModifierInfo(modifierMiddle, middleModifierIn);
        modifierRightName = SetModifierInfo(modifierRight, rightModifierIn);
    } 

    private string SetModifierInfo(GameObject modifierTo, Modifier modifierFrom)
    {
        //Modifiers WILL ONLY have 2 children;
        string modName = "no name";

        //get modifier text fields
        TMP_Text[] textChildren = modifierTo.GetComponentsInChildren<TMP_Text>();

        //go through all children
        for (int i = 0; i < textChildren.Length; i++)
        {
            if (textChildren[i].name == "ModifierName") //set title
            {
                textChildren[i].text = modifierFrom.modifierName;
                modName = modifierFrom.modifierName;
            }
            else if(textChildren[i].name == "Description") //set description
            {
                textChildren[i].text = modifierFrom.description;
            }
        }

        return modName;
    }

    public void DisableModifierCanvas()
    {
        modifierCanvas.gameObject.SetActive(false);
    }

}
