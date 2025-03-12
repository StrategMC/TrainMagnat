using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundData 
{
    public float music_volume;
    public SoundData()
    {
        music_volume = -50;
    }
    public SoundData(float music_volume)
    {   
        this.music_volume = music_volume; 
    }
}
