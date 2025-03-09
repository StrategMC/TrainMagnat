using GlabalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopWindowController : MonoBehaviour,IWeeklyUpdate
{
    public DevelopWindowData data;
    public MoneyController moneyController;
    public FinanseView finanseView; 
    public void Awake()
    {
        data = new DevelopWindowData();
        data.Rashod = 1000;
        data.bonus = 1f;
    }
    public void WeekTick()
    {
        moneyController.RemoveMany(data.Rashod);
        finanseView.data.consumptionfordevelop += data.Rashod;
        //finanseView.View();
    }
    public void Obnova()
    {
        switch (data.lvlFinans)
        {
            case 1:
                data.Rashod = 1000;
                data.bonus = 1f;
                break;
            case 2:
                data.Rashod = 5000;
                data.bonus = 1.2f;
                break;
            case 3:
                data.Rashod = 10000;
                data.bonus = 1.5f;
                break;
            case 4:
                data.Rashod = 20000;
                data.bonus = 2f;
                break;
            case 5:
                data.Rashod = 50000;
                data.bonus = 3f;
                break;
            case 6:
                data.Rashod = 100000;
                data.bonus = 5f;
                break;
            case 7:
                data.Rashod = 150000;
                data.bonus = 10f;
                break;
        }
    }
}
