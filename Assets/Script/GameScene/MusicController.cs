using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] musicTracks;
    public void Start()
    {

        audioSource.clip = musicTracks[PlayerPrefs.GetInt("MusicName")];
        audioSource.time = PlayerPrefs.GetFloat("TimeMusic");
        audioSource.Play();
    }
   
}
