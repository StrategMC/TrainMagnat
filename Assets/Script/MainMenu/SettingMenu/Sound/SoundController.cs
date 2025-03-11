using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public SoundData SoundData;
    public AudioMixerGroup Mixer;
   
    private void Start()
    {
        //SoundData=new SoundData();
        Mixer.audioMixer.SetFloat("Music", SoundData.music_volume);
    }
    public void GetMusicVolume(float value)
    {
        value = 1 - value;
        value = value * (-80);
        SoundData.music_volume=value;
        //Debug.Log(value);
        Mixer.audioMixer.SetFloat("Music", SoundData.music_volume);
    }
}
