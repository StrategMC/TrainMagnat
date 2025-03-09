using GlabalGame;
using GlobalGame;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadController : MonoBehaviour
{
    public List<PlayerData> players;
    public bool IsLoad;

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
    public FinanseView FinanseView;
    public CompanyController Company;
    public DemandController Demand;
    public EnemyController Enemy;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Load") == 1)
        {
            Vyzov();
        }
    }
    void Vyzov()
    {
        string path = Application.persistentDataPath + "/players.json";
        Load(path);
        Debug.Log("Загрузка");   //загрузка
    
    }
    private void Load(string path)
    {
        string json = File.ReadAllText(path);
        PlayerArray players = JsonConvert.DeserializeObject<PlayerArray>(json);
        for (int i = 0; i < players.players.Count; i++)
        {
            if (players.players[i].player_id == PlayerPrefs.GetInt("id player"))
            {
                PlayerData player = players.players[i];
                Time.Time=player.TimeData;
                Money.Money = player.MoneyData;
                Research.researchBonus=player.ReasearchBonus;
                Research.reasearchData=player.ReasearchData;
                Ehine.data=player.EngineData;
                Chassis.data=player.ChassisData;
                Locomotive.data=player.LocomotiveData;
                Sklad.skladData = player.SkladData; 
                Prois.ProisData=player.ProisData;
                Develop.data=player.DevelopWindowData;
                EngineDevelop.dataRes = player.EngineDevelop;
                ChassisWindow.dataRes = player.ChassisDevelop;
                FinanseView.data = player.FinanseView;
                Company.Companies=player.Companies;
                Demand.MarketData = player.Market;
                Demand.demandData = player.Demand;
                Enemy.enemies=player.Enemies;
                //Time.Time,Money.Money, Research.researchBonus, Research.reasearchData, Ehine.data, Chassis.data,
                //Locomotive.data, Sklad.skladData, Prois.ProisData,Develop.data, EngineDevelop.dataRes,
                //ChassisWindow.dataRes, FinanseView.data,Company.Companies, Demand.MarketData, Demand.demandData, Enemy.enemies
            }
        }
   
    }
}
