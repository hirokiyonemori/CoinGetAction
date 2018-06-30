using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {
    public AudioClip audioClip1;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Game.instance.state == Game.STATE.GAMEOVER)
        {
            //if (audioSource.isPlaying()) { 
              
           //audioSource.Stop();
                audioSource.clip = audioClip1;
                audioSource.Play();
            //}
        }
    }
}
