using GlabalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProisController : MonoBehaviour,IWeeklyUpdate
{
   public FinanseView FinanseView;
   public MoneyController moneyController;
   public ProisData ProisData;
   public ProisView ProisView;
   public SkladData SkladData;
   public void AddPoint()
   {
        ProisData.proispoint += 1000;
        ProisData.rashod += 10000;
        ProisView.ViewPoint();
   }
    public void MinusPoint()
    {
        if (ProisData.proispoint > 0)
        {
            ProisData.proispoint -= 1000;
            ProisData.rashod -= 10000;
            ProisView.ViewPoint();
        }

    }
    public void WeekTick()
    {
        if (ProisData.locomotiew.name!=null)
        {
            ProisData.proisinweek = ProisData.proispoint/ProisData.locomotiew.cost;
            ProisView.ViewProis();
            if(SkladData.lovomotivy.ContainsKey(ProisData.locomotiew))
            {
                SkladData.lovomotivy[ProisData.locomotiew] += ProisData.proisinweek;
            }
            else
            {
                SkladData.lovomotivy.Add(ProisData.locomotiew, ProisData.proisinweek);
            }
            moneyController.RemoveMany(ProisData.proispoint);
            FinanseView.consumptionforproduction+=ProisData.proispoint;
        }
        else
        {
           // Debug.Log("Ничего нет в производстве");
        }
        
    }

}
