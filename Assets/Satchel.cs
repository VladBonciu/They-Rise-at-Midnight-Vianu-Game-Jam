using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satchel : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject explosion;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 20f , ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Hit Enemy");
        }

        Debug.Log("Hit");

        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
