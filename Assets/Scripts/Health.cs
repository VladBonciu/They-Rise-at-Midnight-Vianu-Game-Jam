using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] Slider slider;

    void Start()
    {
        health = 100f;
    }
    
    void FixedUpdate()
    {
        slider.value = Mathf.Lerp(slider.value, health, Time.deltaTime * 2f);
    }

    void Die() 
    {
        if (health <= 0) 
        {
            health = 0;
            Debug.Log("You Ded");
        }
    }
}
