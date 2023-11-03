using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager instance;
    public AudioSource footstepAudio;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void Playsound(AudioClip clip)
    {
        footstepAudio.clip = clip;
        footstepAudio.Play();
    }

    public void Stopsound(AudioClip clip)
    {
        footstepAudio.clip = clip;
        footstepAudio.Stop();
    }
}

// Update is called once per frame