using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Notebook : MonoBehaviour
{
    [SerializeField] public bool isUsing;
    [SerializeField] private GameObject notebooksSprite;
    [SerializeField] private GameObject notebooksOverlay;
    [SerializeField] private PlayerMove playerMove;

    void Start()
    {
        isUsing = false;
    }

    public void OnValueChanged()
    {
        isUsing = !isUsing;
        if(isUsing)
        {
            playerMove.canMove = false;
            notebooksOverlay.SetActive(true);;
            notebooksSprite.SetActive(false);
        }
        else
        {
            playerMove.canMove = true;
            notebooksOverlay.SetActive(false);
            notebooksSprite.SetActive(true);
        }
    }
}
