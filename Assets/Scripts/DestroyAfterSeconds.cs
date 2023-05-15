using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] float amount;

    void Awake()
    {
        Destroy(gameObject , amount);
    }

}
