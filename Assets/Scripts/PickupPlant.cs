using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPlant : MonoBehaviour
{
    [SerializeField] GameObject Player;
    
    public void PickedUp() 
    {
        //pickup the matraguna
    Destroy(gameObject);
        Player.GetComponent<Inventory>().MatragunaCounter += 1;  
    }

  
}
