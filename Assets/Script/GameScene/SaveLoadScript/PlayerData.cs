using GlabalGame;
using GlobalGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public TimeData TimeData;
    public MoneyData MoneyData;
    public ReasearchBonus ReasearchBonus;
    public ReasearchData ReasearchData;
    public EngineData EngineData;  
    public ChassisData ChassisData; 
    public LocomotiveData LocomotiveData;
    public SkladData SkladData;
    public ProisData ProisData;
    public DevelopWindowData DevelopWindowData;
    public EngineDevelopReaserchesEnginesData EngineDevelop;
    public ChassisWindowReaserchData ChassisDevelop;
    public FinanseViewData FinanseView;
    public List<CompanyData> Companies;
    public MarketData Market;
    public DemandData Demand;
    public List<EnemyData> Enemies;
    public int player_id;
    public PlayerData(TimeData TimeData, MoneyData MoneyData, ReasearchBonus ReasearchBonus, ReasearchData ReasearchData, EngineData EngineData, ChassisData ChassisData, LocomotiveData LocomotiveData, SkladData SkladData, ProisData ProisData, DevelopWindowData DevelopWindowData, EngineDevelopReaserchesEnginesData EngineDevelop, ChassisWindowReaserchData ChassisDevelop, FinanseViewData FinanseView, List<CompanyData> Companies, MarketData MarketData, DemandData DemandData, List<EnemyData> Enemies)
    {
        player_id = PlayerPrefs.GetInt("id player");
        this.TimeData = TimeData;
        this.MoneyData = MoneyData;
        this.ReasearchBonus = ReasearchBonus;
        this.ReasearchData = ReasearchData;
        this.EngineData = EngineData;
        this.ChassisData = ChassisData;
        this.LocomotiveData = LocomotiveData;
        this.SkladData = SkladData;
        this.ProisData = ProisData;
        this.DevelopWindowData = DevelopWindowData;
        this.EngineDevelop = EngineDevelop;
        this.ChassisDevelop = ChassisDevelop;
        this.FinanseView = FinanseView;
        this.Companies = Companies;
        this.Market = MarketData;
        this.Demand = DemandData;
        this.Enemies=Enemies;
    }

}
