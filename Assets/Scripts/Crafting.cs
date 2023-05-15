using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    [SerializeField] private float satchelTimer = 4;
    [SerializeField] private float bandageTimer = 4;
    [SerializeField] private Inventory inventory;

    
    [SerializeField] Image bandageImage;
    [SerializeField] Image satchelImage;
    [SerializeField] Image matragunaImage;

    private float satchelCop;
    private float bandageCop;

    void Start()
    {
        satchelCop = satchelTimer;
        bandageCop = bandageTimer;
    }

    void Update()
    {
        CraftSatchel();
        CraftBandage();
    }

    void CraftSatchel() 
    {
        if (inventory.matragunaCounter > 0 )
        {
            if (Input.GetKey(KeyCode.E) && bandageTimer == bandageCop)
            {
                satchelTimer -= 1 * Time.deltaTime;
                satchelImage.fillAmount = 1 - satchelTimer/satchelCop;

                matragunaImage.fillAmount = satchelTimer/satchelCop;
            }
            if (Input.GetKeyUp(KeyCode.E) && bandageTimer == bandageCop)
            {
                if(satchelTimer >=  (satchelCop - 0.2f))
                {
                    inventory.UseSatchel();
                }
                satchelImage.fillAmount = 1;
                matragunaImage.fillAmount = 1;

                satchelTimer = satchelCop;

                inventory.UpdateText();
            }
            if (satchelTimer <= 0 && bandageTimer == bandageCop)
            {
                inventory.satchelCounter += 1;
                inventory.matragunaCounter -= 1;
                satchelTimer = satchelCop;

                matragunaImage.fillAmount = 1;

                inventory.UpdateText();
            }
        }
    }

    void CraftBandage()
    {
        if (inventory.matragunaCounter > 0 )
        {
            if (Input.GetKey(KeyCode.Q) && satchelTimer == satchelCop)
            {
                bandageTimer -= 1 * Time.deltaTime;
                bandageImage.fillAmount = 1 - bandageTimer/bandageCop;

                matragunaImage.fillAmount = bandageTimer/bandageCop;
            }
            if (Input.GetKeyUp(KeyCode.Q) && satchelTimer == satchelCop)
            {
                if(bandageTimer >= (bandageCop - 0.2f))
                {
                    inventory.UseBandage();
                }
                bandageImage.fillAmount = 1;
                matragunaImage.fillAmount = 1;

                bandageTimer = bandageCop;

                inventory.UpdateText();
            }
            if (bandageTimer <= 0 && satchelTimer == satchelCop)
            {
                inventory.bandageCounter += 1;
                inventory.matragunaCounter -= 1;
                bandageTimer = bandageCop;

                matragunaImage.fillAmount = 1;

                inventory.UpdateText();
            }
        }
    }
    
}
