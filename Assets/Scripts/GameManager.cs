using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyCode toggleToolkit;
    [SerializeField] private GameObject Toolkit;
    [SerializeField] private bool isToolkitOpen;
    [SerializeField] private Animator toolkitAnimator;

    [SerializeField] private bool isUsingBinoculars;
    [SerializeField] private bool isUsingNotebook;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isToolkitOpen = false;
        Toolkit.SetActive(false);
        isUsingNotebook = false;
        isUsingBinoculars = false;
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
    
}
