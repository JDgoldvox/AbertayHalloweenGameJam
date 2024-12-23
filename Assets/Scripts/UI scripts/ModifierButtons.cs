using UnityEngine;

public class ModifierButtons : MonoBehaviour
{
    public void LeftModifier()
    {
        string name = UIManager.Instance.modifierLeftName;
        ModifierManager.Instance.AddModifier(name);
        UIManager.Instance.DisableModifierCanvas();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void MiddleModifier()
    {
        string name = UIManager.Instance.modifierMiddleName;
        ModifierManager.Instance.AddModifier(name);
        UIManager.Instance.DisableModifierCanvas();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void RightModifier()
    {
        string name = UIManager.Instance.modifierRightName;
        ModifierManager.Instance.AddModifier(name);
        UIManager.Instance.DisableModifierCanvas();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
