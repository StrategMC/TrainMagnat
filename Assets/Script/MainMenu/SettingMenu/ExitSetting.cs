using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

public class ExitSetting : MonoBehaviour 
{
    public SoundController ControllerSound;
    public Button ExitButton;
    private SettingData SettingData;
    private void Awake()
    {

        ExitButton.onClick.AddListener(Exit);
    }
    private void Load()
    {
        string path = Application.persistentDataPath + "/setting.json";
        if (File.Exists(path))
        {
            SettingData=JsonConvert.DeserializeObject<SettingData>(File.ReadAllText(path));
            ControllerSound.
        }
    }
    private void Exit()
    {
        SettingData = new SettingData(ControllerSound.SoundData);
        string path = Application.persistentDataPath + "/setting.json";
        string json=JsonConvert.SerializeObject(SettingData);
        File.WriteAllText(path, json);
    }
}
public class SettingData
{
    public SoundData SoundData;
    public SettingData(SoundData soundData)
    {
        SoundData = soundData;
    }
}
