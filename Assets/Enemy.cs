using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float speedcop = 10;
    [SerializeField] float hitSpeed = 1;
    [SerializeField] float damage = 20;
    bool aggresive = false;
    bool dormant = true;
    bool canAttack = false;
    float t;
   [SerializeField] float hitTimer = 4;
    [SerializeField] float hitTimerCop;
    [SerializeField ]float dormantRange = 20f ;//ca sa devi aggro
    public bool hit; 
    
    [SerializeField] float attackTimer = 4;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        speedcop = speed;
        hitTimerCop = hitTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) 
        {
            speed = hitSpeed;
            hitTimer -= 1 * Time.deltaTime;
        }
        if (hitTimer <= 0) 
        {
            hit = false;
            hitTimer = hitTimerCop;
        }


        t = speed * Time.deltaTime;
        Aggresive();
        if (aggresive == true) 
        {
            transform.position = Vector3.Lerp(transform.position,player.transform.position, t );
         if(canAttack )
                StartCoroutine(Attack());
        }
        Debug.DrawLine(transform.position,new Vector3(dormantRange,dormantRange,dormantRange));

      
    }
   
    void Aggresive() 
    {
        if (Vector3.Distance(transform.position,player.transform.position) < dormantRange) 
        {
        aggresive = true;
        }
        
    }

    IEnumerator Attack()
    {

        canAttack = false;
        player.GetComponent<Health>().health -= damage;
        Debug.Log("PlayerHit");
        player.GetComponent<Rigidbody>().AddForce(transform.forward*10, ForceMode.Impulse);
        yield return new WaitForSeconds(attackTimer);
        canAttack = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canAttack = true;
            Debug.Log("Can attack");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canAttack = false;
            Debug.Log("Cant attack");
        }
    }
}
