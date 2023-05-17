using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Inventory : MonoBehaviour
{
    public float matragunaCounter = 0;
    public float bandageCounter = 0;
    public float satchelCounter = 0;
    [SerializeField] float heal = 10;
    public PlayerAudio playeraudio;
    [SerializeField] TMP_Text matragunaText;
    [SerializeField] TMP_Text bandageText;
    [SerializeField] TMP_Text satchelText;


    [SerializeField] SatchelThrower thrower;

    void Start()
    {
        UpdateText();
        playeraudio = GetComponent<PlayerAudio>();
    }


    void FixedUpdate()
    {
        
    }

    public void UseBandage()
    {
        if(bandageCounter > 0)
        {
            Debug.Log("Bandaged");
            bandageCounter--;
            GetComponent<Health>().health += heal;
            UpdateText();
            playeraudio.bandageSound.Play();
           
        }
        
    }

    public void UseSatchel()
    {
        if(satchelCounter > 0)
        {
            thrower.Shoot();

            Debug.Log("Satcheled");

            satchelCounter--;
            playeraudio.satchelSound.Play();

            UpdateText();
        }
    }

    public void UpdateText()
    {
        satchelText.text = satchelCounter.ToString("");
        bandageText.text = bandageCounter.ToString("");
        matragunaText.text = matragunaCounter.ToString("");
    }
}
