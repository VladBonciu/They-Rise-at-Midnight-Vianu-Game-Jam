using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject ControlsPanel; 

    [SerializeField] private Toggle toggle;

    void Awake()
    {
        ControlsPanel.SetActive(toggle.isOn);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Play()
    {
        SceneManager.LoadScene(1 ,LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleControls()
    {
        ControlsPanel.SetActive(toggle.isOn);
    }
}
