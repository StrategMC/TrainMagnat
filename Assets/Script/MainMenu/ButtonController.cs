using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public SoundController SoundController;
    public Button ButtonAutoriacion;
    public Button ButtonNewPlay;
    public Button ButtonContinuePlay;
    public Button ButtonSetting;
    public Button ButtonSettingExit;
    public GameObject SettingPanel;
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("id player"));
        ButtonAutoriacion.onClick.AddListener(AutorizacionButtonCklick);
        ButtonNewPlay.onClick.AddListener(NewPlay);
        ButtonContinuePlay.onClick.AddListener(ContinuePlay);
        ButtonSetting.onClick.AddListener(SettingOpen);
        ButtonSettingExit.onClick.AddListener(SettingClose);
    }
    void SettingOpen()
    {
        SettingPanel.gameObject.SetActive(true);
    }
    void SettingClose()
    {
        SettingPanel.gameObject.SetActive(false);
    }
    void AutorizacionButtonCklick()
    {
        SceneManager.LoadScene("RA");
    }
    void NewPlay()
    {
        PlayerPrefs.SetInt("Load", 0);
        PlayerPrefs.Save();
        Play();
    }
    void ContinuePlay()
    {
        PlayerPrefs.SetInt("Load", 1);
        PlayerPrefs.Save();
        Play();
    }
    private void Play()
    {
        SoundController.SaveMusic();
        SceneManager.LoadScene("SampleScene");
    }
}
