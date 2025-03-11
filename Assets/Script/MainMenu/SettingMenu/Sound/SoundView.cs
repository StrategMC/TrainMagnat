using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundView : MonoBehaviour
{
    public Text VolumeText;
    public SoundController SoundController;

    public Slider Slider;
    private void Start()
    {
        Slider.value = SoundController.SoundData.music_volume;
        Slider.onValueChanged.AddListener(ChangeVolumeMusic);
    }
    void ChangeVolumeMusic(float value)
    {
        SoundController.GetMusicVolume(value);
        ViewVolumeMusicText((int)(value*100));
    }
    void ViewVolumeMusicText(int n)
    {
        VolumeText.text = $"{n}%";
    }
}
