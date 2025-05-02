using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip SoundToPlay;
    public float volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(SoundToPlay, volume);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
