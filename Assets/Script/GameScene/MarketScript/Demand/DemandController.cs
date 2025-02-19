using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandController : MonoBehaviour, IWeeklyUpdate
{
    public MarketData MarketData;
    public void AddDemand(LineData line, int col)
    {
        Demand temp= new Demand(line, col); 
        MarketData.demands.Add(temp);
    }
    public  void WeekTick()
    {
        for (int i = 0; i < MarketData.demands.Count; i++)
        {
           // Debug.Log(BestSuply().loco.name);
        }
    }
    Supply BestSuply()
    {
        Supply best=new Supply();
        int[] sum=new int[MarketData.supplys.Count];
        float cost = 0.3f;
        float power = 0.4f;
        float speed = 0.4f;
        for(int i=0; i<MarketData.supplys.Count;i++)
        {
            sum[i] += (int)((float)MarketData.supplys[i].loco.power * power);
            sum[i] += (int)((float)MarketData.supplys[i].loco.speed * speed);
            sum[i] -= (int)((float)MarketData.supplys[i].cost * cost/100);
        }
        return best;
    }
    private void MinusDemand(LineData line,int col)
    {
        if(line.needLoc<=line.Locomotives.Count)
        {
            for(int i = 0; i < MarketData.demands.Count;i++)
            {
                if(MarketData.demands[i].line==line)
                {
                    MarketData.demands.RemoveAt(i);
                }
            }
           
        }
    }
}
