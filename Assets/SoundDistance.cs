using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDistance : MonoBehaviour
{
    public AudioSource caveSounds;
    public GameObject player;
    [SerializeField] float soundRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < soundRange)
        {
            caveSounds.enabled = true;
        }
        else 
        {
            caveSounds.enabled = false;
        }
    }
}
