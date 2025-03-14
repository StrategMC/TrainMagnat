using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip[] musicTracks;
    public SoundData SoundData;
    public AudioMixerGroup Mixer;
   
    private void Awake()
    {
        if(PlayerPrefs.HasKey("Music"))
        {
            SoundData = new SoundData(PlayerPrefs.GetFloat("Music"));
            //Debug.Log($"PlayerPrefs: {PlayerPrefs.GetFloat("Music")}");
            //Debug.Log($"Controller: {SoundData.music_volume}");
        }
        else
        {
            SoundData = new SoundData();
        }
        Mixer.audioMixer.SetFloat("Music", SoundData.music_volume);
    }
    public void GetMusicVolume(float value)
    {
        SoundData.music_volume=value;
        PlayerPrefs.SetFloat("Music", SoundData.music_volume);
       // Debug.Log(PlayerPrefs.GetFloat("Music"));
        Mixer.audioMixer.SetFloat("Music", SoundData.music_volume);
    }
    public void OnMusicSelected(int index)
    {
        if (index >= 0 && index < musicTracks.Length)
        {
            audioSource.Stop();
            audioSource.clip = musicTracks[index];
            audioSource.Play();
            PlayerPrefs.SetInt("MusicName", index);
        }
    }
    public void SaveMusic()
    {
        PlayerPrefs.SetFloat("TimeMusic", audioSource.time);
        PlayerPrefs.Save();
    }
}
