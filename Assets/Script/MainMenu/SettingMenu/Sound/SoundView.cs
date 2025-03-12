using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundView : MonoBehaviour
{
    public Text VolumeText;
    public SoundController SoundController;
    public Dropdown musicDropdown;
    public Sprite[] Cartinki;
    public SpriteRenderer Ramka;
    public Slider Slider;
    public void Start()
    {
        Slider.value = SoundController.SoundData.music_volume;
        //Debug.Log("Music vlaue " + SoundController.SoundData.music_volume);
        //Debug.Log("Sl vlaue "+Slider.value);
        Slider.onValueChanged.AddListener(ChangeVolumeMusic);
        ViewVolumeMusicText(Slider.value);
        musicDropdown.onValueChanged.AddListener(SoundController.OnMusicSelected);
        musicDropdown.onValueChanged.AddListener(ChangeImage);
    }
    void ChangeImage(int i)
    {
        Ramka.sprite = Cartinki[i];
    }
    void ChangeVolumeMusic(float value)
    {
        SoundController.GetMusicVolume(value);
        ViewVolumeMusicText(value);
    }
    void ViewVolumeMusicText(float n)
    {
        int viewint=(int)((n+50)*2);
        VolumeText.text = $"{viewint}%";
    }
   
}
