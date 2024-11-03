using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    
    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("BloodBoundHarvest");
    }

    public void QuitGame() { 
        Application.Quit();
    }
}
