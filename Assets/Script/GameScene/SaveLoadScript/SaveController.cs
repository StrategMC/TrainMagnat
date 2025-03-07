using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using GlobalGame;
using System.IO;
using static UnityEditor.Experimental.GraphView.GraphView;
using GlabalGame;

public class SaveController : MonoBehaviour
{
    public Button ExitButtton;
    public TimeController Time;
    public MoneyController Money;
    public ResearchController Research;
    public ChassisController Chassis;
    public EhineController Ehine;
    public LocomotiveController Locomotive;
    public SkladController Sklad;
    public ProisController Prois;
    public DevelopWindowController Develop;
    public ChassisWindowReaserch ChassisWindow;
    public EngineDevelopReaserchesEngines EngineDevelop;
    void Start()
    {
        ExitButtton.onClick.AddListener(ExitAndSave);
    }

    void ExitAndSave()
    {
        SceneManager.LoadScene("MainMenu");
        Save();
    }

    PlayerArray Load(string path)
    {
        if (FileNotNull(path))
        {
            string json = File.ReadAllText(path);
            PlayerArray players = JsonConvert.DeserializeObject<PlayerArray>(json);
          
            return players;
        }
        else
        {
            PlayerArray players = new PlayerArray();
            return players;
        }
    }

    int ThisPlayerNum(PlayerArray players)
    {
        for (int i = 0; i < players.players.Count; i++)
        {
            if (players.players[i].player_id == PlayerPrefs.GetInt("id player"))
            {
                return i;
            }
        }
        return 0;
    }

    bool HaveThisPlayer(PlayerArray players)
    {
        for (int i = 0; i < players.players.Count; i++)
        {
            if (players.players[i].player_id == PlayerPrefs.GetInt("id player"))
            {
              //  Debug.Log("Есть");
                return true;
            }
        }
        //Debug.Log("Нет");
        return false;
    }
    bool FileNotNull(string path)
    {
        if (File.Exists(path)) return true;
        else return false;
    }    
    void Save()
    {
        string path = Application.persistentDataPath + "/players.json";
        PlayerArray players = Load(path);
        PlayerData playerData = new PlayerData(Time.Time,Money.Money, Research.researchBonus, Research.reasearchData, Ehine.data, Chassis.data, Locomotive.data, Sklad.skladData, Prois.ProisData,Develop.data, EngineDevelop.dataRes,  ChassisWindow.dataRes);
        if (HaveThisPlayer(players))
        {
            players.players[ThisPlayerNum(players)] = playerData;
        }
        else
        {
            players.players.Add(playerData);
        }

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        string json = JsonConvert.SerializeObject(players, settings);
        //Debug.Log(json);
        File.WriteAllText(path, json);
       // Debug.Log($"{Application.persistentDataPath + "/players.json"}");
    }
}

public class PlayerArray
{
    public List<PlayerData> players;
    public PlayerArray() { players = new List<PlayerData>(); }
}
