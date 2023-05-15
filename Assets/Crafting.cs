using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    [SerializeField] float SatchelTimer = 4;
    [SerializeField] float BandageTimer = 4;
    [SerializeField] GameObject Player;
    float SatchelCop;
    float BandageCop;
    // Start is called before the first frame update
    void Start()
    {
        SatchelCop = SatchelTimer;
        BandageCop = BandageTimer;
    }

    // Update is called once per frame
    void Update()
    {
        CraftSatchel();

    }
    void CraftSatchel() 
    {
        if (Player.GetComponent<Inventory>().MatragunaCounter > 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                SatchelTimer -= 1 * Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                SatchelTimer = SatchelCop;
            }
            if (SatchelTimer <= 0)
            {
                Player.GetComponent<Inventory>().SatchelCounter += 1;
                Player.GetComponent<Inventory>().MatragunaCounter -= 1;
                SatchelTimer = SatchelCop;
            }
        }
    }
    void CraftBandage()
    {
        if (Player.GetComponent<Inventory>().MatragunaCounter > 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                BandageTimer -= 1 * Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                BandageTimer = BandageCop;
            }
            if (SatchelTimer <= 0)
            {
                Player.GetComponent<Inventory>().BandageCounter += 1;
                Player.GetComponent<Inventory>().MatragunaCounter -= 1;
                BandageTimer = BandageCop;
            }
        }
    }
}
