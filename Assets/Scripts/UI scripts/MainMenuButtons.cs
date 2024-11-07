using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Settings _settings;
    public Slider _slider;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("BloodBoundHarvest");
    }

    public void QuitGame() { 
        Application.Quit();
    }

    public void SetSens()
    {
        _settings.sensitivity = _slider.value;
    }
}
