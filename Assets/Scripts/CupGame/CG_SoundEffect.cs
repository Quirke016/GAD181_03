using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CG_SoundEffect : MonoBehaviour
{
    public AudioClip[] soundShuffle;
    public AudioClip[] soundBall;
    //private AudioSource audioSource;



    void Start()
    {

    }

  /*  public void PlayRandomSound(int type)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        int randomIndex = Random.Range(0, soundShuffle.Length);
        audioSource.clip = soundShuffle[randomIndex];
        audioSource.Play();
        Invoke("StopSound", 0.1f);

    }
*/

    public void PlayRandomSound(int type=0)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        AudioClip[] audioPlaySet;
        if (type == 0)
        {
            audioPlaySet = soundShuffle;
        }
        else if (type == 1)
        {
 
            audioPlaySet = soundBall;
        }
        else
        {
            audioPlaySet = null;
        }





        if (audioPlaySet != null)
        {
            int randomIndex = Random.Range(0, audioPlaySet.Length);
            audioSource.clip = audioPlaySet[randomIndex];
            audioSource.Play();
            Invoke("StopSound", 0.1f);
        }
        else
        {
            Debug.Log("error type was not proved so could play sound");
        }
        

    }

    void Update()
    {
        /*  if (Input.GetKeyDown(KeyCode.K))
          {
              PlayRandomSound();
          }*/
        
    }

    void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }
}



