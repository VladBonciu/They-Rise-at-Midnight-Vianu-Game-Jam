using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPlant : MonoBehaviour
{
    public Inventory inventory;
    public AudioClip pickupClip;

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        
    }
    
    public void PickedUp() 
    {
        //pickup the matraguna
        
        StartCoroutine(PickupWithSound());

        
        inventory.matragunaCounter += 1;  
        inventory.UpdateText();
        
    }

    public void PickedUpFiara() 
    {
        //pickup the matraguna
        Destroy(gameObject); 

    }

    IEnumerator PickupWithSound()
    {
        AudioSource pickup = gameObject.AddComponent<AudioSource>();
        pickup.spatialBlend = 0.5f;
        pickup.clip = pickupClip;
        pickup.Play();

        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }

  
}
