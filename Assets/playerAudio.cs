using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class playerAudio : MonoBehaviour
{
    public AudioClip[] audioclip;
   public AudioSource[] audioSource;

    private void Start()
    {
        audioSource = GetComponents<AudioSource>();
    }
    private void Update()
    {
        if(Gamepad.current.leftStick.IsActuated() && FindAnyObjectByType<Movement>().isGrounded)
        {
            audioSource[0].volume = 1f;
        }
        else
        {
            audioSource[0].volume = 0;
        }
        
    }
    public void playSound(string soundName)
    {
       
       
            switch (soundName)
            {
                case "Jump":
                if (!audioSource[1].isPlaying)
                    
                    audioSource[1].PlayOneShot(audioclip[1]);
                
                    break;
                case "Death":
                if (!audioSource[1].isPlaying)
                    audioSource[1].PlayOneShot(audioclip[2]);
                    audioSource[1].PlayOneShot(audioclip[3]);
                    break;
            
        }
     
         
    }
}
