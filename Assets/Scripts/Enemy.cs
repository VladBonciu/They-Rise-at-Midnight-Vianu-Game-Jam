using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
     float speedcop;
    [SerializeField] float hitSpeed = 1;
    [SerializeField] float damage = 20;


    bool aggresive = false;
    bool dormant = true;
    bool canAttack;
    bool isAttacking;
    [SerializeField ]float dormantRange = 20f ;//ca sa devi aggro
    public bool isHit; 

    [SerializeField] float hitTimer = 4;
    [SerializeField] float attackTimer = 4;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mesh;
    [SerializeField] LayerMask maskPlayer;

    [SerializeField] Animator animator;

    Rigidbody rb;
    
    void Start()
    {
        speedcop = speed;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // t = speed * Time.deltaTime;
        // if (aggresive == true) 
        // {
        //     transform.position = Vector3.Lerp(transform.position,player.transform.position, t );
        // }

        if (Vector3.Distance(transform.position,player.transform.position) < dormantRange) 
        {
            aggresive = true;
            Aggresive();
        }
        else
        {
            aggresive = false;
        }
      
    }
   
    void Aggresive() 
    {

        animator.SetTrigger("Floats");
        Debug.Log("Agressive");

        RaycastHit hit;

        Vector3 heading = player.transform.position - transform.position;

        float distance = heading.magnitude;
        Vector3 direction = heading / distance;

        mesh.transform.LookAt(player.transform.position, Vector3.up);

        rb.MovePosition(Vector3.Lerp(transform.position ,transform.position + heading.normalized , speed * Time.deltaTime));
        // transform.position = Vector3.Lerp(transform.position,player.transform.position, Time.deltaTime * speed);

        if(Physics.Raycast(transform.position, heading.normalized, out hit, 2f, maskPlayer) && !isAttacking)
        {
            StartCoroutine(Attack());
            Debug.Log("attack!");
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        player.GetComponent<Health>().health -= damage;
        Debug.Log("PlayerHit");
        player.GetComponent<Rigidbody>().AddForce(mesh.transform.forward * 10, ForceMode.Impulse);
        yield return new WaitForSeconds(attackTimer);
        isAttacking = false;
    }

    public void GetHit()
    {
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        isHit = true;
        speed = hitSpeed;
        yield return new WaitForSeconds(hitTimer);
        speed = speedcop;
        isHit = false;
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         canAttack = true;
    //         Debug.Log("Can attack");
    //     }
        
    // }
    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         canAttack = false;
    //         Debug.Log("Cant attack");
    //     }
    // }
}
