using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Inventory : MonoBehaviour
{
    public float matragunaCounter = 0;
    public float bandageCounter = 0;
    public float satchelCounter = 0;

    [SerializeField] TMP_Text matragunaText;
    [SerializeField] TMP_Text bandageText;
    [SerializeField] TMP_Text satchelText;

    void Start()
    {
        UpdateText();
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

            UpdateText();
        }
        
    }

    public void UseSatchel()
    {
        if(satchelCounter > 0)
        {
            Debug.Log("Satcheled");
            satchelCounter--;


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
