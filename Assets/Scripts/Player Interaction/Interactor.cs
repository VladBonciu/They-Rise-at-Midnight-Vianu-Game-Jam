using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactor : MonoBehaviour
{

    [SerializeField] private bool isInteracting;
    [SerializeField] private bool canInteract; 
    [SerializeField] private int interactIndex = 0;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private TMP_Text optionText;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private Animator selectOption;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float distance;

    void Start()
    {
        isInteracting = false;
        canInteract = true;

        // Cursor.lockState = CursorLockMode.Locked;
    }

    RaycastHit hit;
    

    void Update()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance, layerMask))
        {
            if(hit.transform.gameObject.GetComponent<Interactable>() && canInteract)
            {
                if(!isInteracting)
                {
                    interactIndex = 0;
                    isInteracting = true;
                }
                
                Interactable interactableScript = hit.transform.gameObject.GetComponent<Interactable>();
                

                if(Input.mouseScrollDelta.y * 10 > 0f)
                {
                    if((interactIndex + 1) <= interactableScript.interactOptions.Count - 1)
                    {
                        interactIndex++;
                        selectOption.Play("ChangeOption");
                        
                    }
                    
                }
                if(Input.mouseScrollDelta.y * 10 < 0f)
                {
                    if((interactIndex - 1) >= 0)
                    {
                        interactIndex--;
                        selectOption.Play("ChangeOption");
                    }
                }              

                if(selectOption.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                {
                    selectOption.Play("Idle");
                }

                crosshair.SetActive(false);

                optionText.text = interactableScript.interactOptions[interactIndex].interactingTextShown;
                countText.text = interactIndex + 1 + "/" + interactableScript.interactOptions.Count;

                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    interactableScript.Interact(interactableScript.interactOptions[interactIndex]);
                    selectOption.Play("Selected");
                    canInteract = true;
                }

            }
        }
        else
        {
            canInteract = true; 
            crosshair.SetActive(true);
            selectOption.Play("Idle");
            isInteracting = false;
            optionText.text = "";
            countText.text = "";
        }
    }
}
