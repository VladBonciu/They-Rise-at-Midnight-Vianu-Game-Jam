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
        rb.AddForce(transform.forward * 25f , ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hit");

        if(col.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("Hit Enemy");
            col.gameObject.GetComponent<Enemy>().GetHit();
        }

        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
