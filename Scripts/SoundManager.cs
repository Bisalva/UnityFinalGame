using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

    }

    public void _PlaySound(AudioClip Sound)
    {
        audioSource.PlayOneShot(Sound);
    }

    public void _PlayMusic(AudioClip Clip)
    {
        musicSource.clip = Clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void _StopMusic()
    {
        musicSource.Stop();
    }

}
