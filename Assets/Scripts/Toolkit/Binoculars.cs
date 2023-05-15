using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Binoculars : MonoBehaviour
{
    [SerializeField] public bool isUsing;
    [SerializeField] private GameObject BinocularVolume;
    [SerializeField] private GameObject binocularsSprite;
    [SerializeField] private GameObject binocularsOverlay;
    [SerializeField] private PlayerLook playerLook;

    void Start()
    {
        isUsing = false;
        
    }

    public void OnValueChanged()
    {
        isUsing = !isUsing;
        if(isUsing)
        {
            BinocularVolume.SetActive(true);
            binocularsOverlay.SetActive(true);
            playerLook.LockFOV(20f);
            binocularsSprite.SetActive(false);
        }
        else
        {
            BinocularVolume.SetActive(false);
            binocularsOverlay.SetActive(false);
            playerLook.UnlockFOV();
            binocularsSprite.SetActive(true);
        }
    }
}
