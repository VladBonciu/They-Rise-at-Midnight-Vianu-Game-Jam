using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyCode toggleToolkit;
    [SerializeField] private GameObject Toolkit;
    [SerializeField] private bool isToolkitOpen;
    [SerializeField] private Animator toolkitAnimator;

    [SerializeField] private bool isUsingBinoculars;
    [SerializeField] private bool isUsingNotebook;

    [SerializeField] private TMP_Text[] matriceDeVizitare;
    public int locationCount;

    [SerializeField] private  PlayerLook playerLook;
    [SerializeField] private  PlayerMove playerMove;
    [SerializeField] private  Health HP;

    [SerializeField] private GameObject InfoPanel;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        isToolkitOpen = false;
        Toolkit.SetActive(false);
        isUsingNotebook = false;
        isUsingBinoculars = false;

        foreach(TMP_Text text in matriceDeVizitare)
        {
            text.text = "o";
        }

        locationCount = 0;

        playerMove.canMove = false;
        playerLook.mouseSensitivity = 0f;

        InfoPanel.SetActive(true);
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(HP.health <= 0)
        {
            Lose();
        }

        if(locationCount == 5)
        {
            Win();
        }

        if(Input.GetKeyDown(toggleToolkit) && !isUsingNotebook)
        {
            if(!isToolkitOpen)
            {
                Cursor.lockState = CursorLockMode.Confined;
                
                StartCoroutine(OpenToolkit());
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                
                StartCoroutine(CloseToolkit());
            }
            
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0 ,LoadSceneMode.Single);
        }
    }

    public void isWriting(Notebook notebook)
    {
       isUsingNotebook = notebook.isUsing;
    }

    public void isUsingBinocular(Binoculars binoculars)
    {
       isUsingBinoculars = binoculars.isUsing;
    }

    public IEnumerator OpenToolkit()
    {
        Toolkit.SetActive(true);
        if(toolkitAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            toolkitAnimator.Play("OpenToolkit");
            yield return new WaitForSeconds(.5f);
        }
        isToolkitOpen = true;
    }

    public IEnumerator CloseToolkit()
    {
        if(toolkitAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            toolkitAnimator.Play("CloseToolkit");
            yield return new WaitForSeconds(.5f);
        }
        Toolkit.SetActive(false);
        isToolkitOpen = false;
    }

    public void CompleteLocation(int index)
    {
        matriceDeVizitare[index].text = "x";

        locationCount = locationCount + 1;
        
    }

    void Win()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void Lose()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        InfoPanel.SetActive(false);
        playerMove.canMove = true;
        playerLook.mouseSensitivity = 100f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
