using UnityEngine;

[CreateAssetMenu(fileName = "custom modifier", menuName = "Custom Modifier")]
public class Modifier : ScriptableObject
{
    public string modifierName;
    public string description;
    public Sprite sprite;
}