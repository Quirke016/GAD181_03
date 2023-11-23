using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_SoundPlayer : MonoBehaviour
{
    // Refence for the sound effects
    public AudioClip[] soundSimbol;
    public AudioClip soundWrong;
    //AudioSource audioSource;
    
    public void PlaySymbolSound(int type)
    {
        if (type == 0)//(colorName == "yellow")
        {
            PlaySound(soundSimbol[0]);
        }
        else if (type == 1)//(colorName == "purple")
        {
            PlaySound(soundSimbol[1]);
        }
        else if (type == 2)//(colorName == "blue")
        {
            PlaySound(soundSimbol[2]);
        }
        else if (type == 3)//(colorName == "red")
        {
            PlaySound(soundSimbol[3]);
        }
        else if (type == 4)
            {
            PlayWrong();
        }
        else
        {
            Debug.Log("error type was not proved so could play sound");
        }
    }

    public void PlayWrong()
    {
        PlaySound(soundWrong);
    }

    void PlaySound(AudioClip sound)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.Play();
        //Invoke("StopSound", 0.1f);
    }


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }
}
