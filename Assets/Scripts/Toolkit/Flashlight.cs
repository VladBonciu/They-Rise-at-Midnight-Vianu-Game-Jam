using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public bool isOn;
    public GameObject lightSource;
    public Sprite spriteOn;
    public Sprite spriteOff;

    void Start()
    {
        isOn = false;
        lightSource.SetActive(false);
    }

    public void OnValueChanged(Image image)
    {
        isOn = !isOn;
        if(isOn)
        {
            lightSource.SetActive(true);
            image.sprite = spriteOn;
        }
        else
        {
            lightSource.SetActive(false);
            image.sprite = spriteOff;
        }
    }
}
