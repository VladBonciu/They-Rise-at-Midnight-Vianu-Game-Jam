using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPlant : MonoBehaviour
{
    public Inventory inventory;
    public AudioSource pickup;
    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        
    }
    
    public void PickedUp() 
    {
        //pickup the matraguna
        Destroy(gameObject);
        inventory.matragunaCounter += 1;  
        inventory.UpdateText();
        pickup.Play();
    }

    public void PickedUpFiara(int index) 
    {
        //pickup the matraguna
        Destroy(gameObject); 

    }

  
}
