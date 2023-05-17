using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource bandageSound;
    public AudioSource satchelSound;
    public AudioSource stepSound;
    public PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(playerMove.moveDirection != Vector3.zero)
        {
            if(Input.GetKey(playerMove.sprintKey))
            {
                stepSound.pitch = Mathf.Lerp(stepSound.pitch, 2, Time.deltaTime * 1f);
            }
            else
            {
                stepSound.pitch = Mathf.Lerp(stepSound.pitch, 1, Time.deltaTime * 1f);
            }
        }
    }
}
