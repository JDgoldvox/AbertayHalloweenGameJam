using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    [SerializeField] private List<Modifier> modifiers;

    public static ModifierManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UIManager.Instance.EnableModifierCanvas(ReturnRandomModifier(), ReturnRandomModifier(), ReturnRandomModifier());
    }
    public Modifier ReturnRandomModifier()
    {
        int randomIndex = UnityEngine.Random.Range(0, modifiers.Count);
        return modifiers[randomIndex];
    }
}
