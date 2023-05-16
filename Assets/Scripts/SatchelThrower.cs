using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatchelThrower : MonoBehaviour
{
    [SerializeField] private GameObject satchelPrefab;

    public void Shoot()
    {
        Instantiate(satchelPrefab, transform.position, transform.rotation);
    }
}
