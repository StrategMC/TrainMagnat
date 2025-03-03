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
    public int player_id;
    public PlayerData(TimeData TimeData, MoneyData MoneyData, ReasearchBonus ReasearchBonus, ReasearchData ReasearchData, EngineData EngineData, ChassisData ChassisData, LocomotiveData LocomotiveData)
    {
        player_id = PlayerPrefs.GetInt("id player");
        this.TimeData = TimeData;
        this.MoneyData= MoneyData;
        this.ReasearchBonus = ReasearchBonus;
        this.ReasearchData = ReasearchData;
        this.EngineData = EngineData;
        this.ChassisData = ChassisData;
        this.LocomotiveData = LocomotiveData;
    }

}
