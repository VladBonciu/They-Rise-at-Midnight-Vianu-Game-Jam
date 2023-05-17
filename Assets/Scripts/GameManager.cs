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


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isToolkitOpen = false;
        Toolkit.SetActive(false);
        isUsingNotebook = false;
        isUsingBinoculars = false;

        foreach(TMP_Text text in matriceDeVizitare)
        {
            text.text = "o";
        }
    }

    // Update is called once per frame
    void Update()
    {
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

        int ok = 1;

        for (int i = 0; i < 3; i++)
        {
            if(matriceDeVizitare[i].text != matriceDeVizitare[i].text && matriceDeVizitare[i].text != "x")
            {
                ok = 0;
            }
        }

        if(ok == 1)
        {
            Debug.Log("You Win!!!");
        }
    }
    
}
