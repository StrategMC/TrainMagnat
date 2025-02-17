using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandController : MonoBehaviour
{
    public MarketData MarketData;
    public void AddDemand(LineData line, int col)
    {
        Demand temp= new Demand(line, col); 
        MarketData.demands.Add(temp);
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
