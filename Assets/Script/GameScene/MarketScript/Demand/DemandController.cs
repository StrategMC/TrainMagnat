using GlabalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemandController : MonoBehaviour, IWeeklyUpdate
{
    public MoneyController MoneyController;
    public MarketData MarketData;
    public MarketView MarketView;
    public FinanseView finanseView;
    public ItogView itogView;

    public DemandData demandData;
    void Awake()
    {
        if (PlayerPrefs.GetInt("Load") == 0)
        {
            MarketData = new MarketData();
            demandData = new DemandData();
        }
        else
        {
            MarketView.LastPredlogenieView();
            MarketView.LastDemandView();
        }
        itogView.Init(demandData.lastWeekAllSell, demandData.lastWeekPlayerSell, demandData.lastWeekProfit);
        itogView.View();
        
    }

    public void AddDemand(LineData line, int col)
    {
        Demand temp = new Demand(line, col);
        MarketData.demands.Add(temp);
    }

    public void WeekTick()
    {
        MarketData.Lastsupplys.Clear();
        MarketData.Lastsdemands.Clear();
        foreach (var supply in MarketData.supplys)
        {
            MarketData.Lastsupplys.Add(new Supply(supply.CompanyName, supply.loco, supply.col, supply.cost));
        }
        foreach (var demand in MarketData.demands)
        {
            MarketData.Lastsdemands.Add(new Demand(demand.line, demand.col));
        }
       
        MarketView.PredlogenieView();
        MarketView.DemandView();

        finanseView.data.profitforlocomotievesell += demandData.profit;

        demandData.lastWeekAllSell = demandData.allsell;
        demandData.lastWeekPlayerSell = demandData.playersell;
        demandData.lastWeekProfit = demandData.profit;
        
      
        itogView.Init(demandData.lastWeekAllSell, demandData.lastWeekPlayerSell, demandData.lastWeekProfit);
        itogView.View();

        

        List<Demand> demandsToRemove = new List<Demand>();
        demandData.allsell = 0;
        demandData.playersell = 0;
        demandData.profit = 0;
        for (int i = 0; i < MarketData.demands.Count; i++)
        {
            LineData line = MarketData.demands[i].line;

            while (line.Locomotives.Count < line.needLoc && MarketData.supplys.Count > 0)
            {
                demandData.allsell++;
                if (!BuyLoco(line))
                {
                    break;
                }
            }

            if (line.needLoc <= line.Locomotives.Count)
            {
                demandsToRemove.Add(MarketData.demands[i]);
            }
        }
        foreach (var demand in demandsToRemove)
        {
            MarketData.demands.Remove(demand);
        }

       
    }

    private bool BuyLoco(LineData line)
    {
        int index = BestSuply();
        if (MarketData.supplys[index].cost > 10000)
        {
           
            return false;
        }

        Supply bestSupply = MarketData.supplys[index];

        CompanyLocomotiveData newLoco = new CompanyLocomotiveData(bestSupply.loco.name, 20);

        line.Locomotives.Add(newLoco);

        bestSupply.col -= 1;
        if (bestSupply.CompanyName == "Player")
        {
            demandData.playersell++;
            demandData.profit += bestSupply.cost;
            MoneyController.AddMany(bestSupply.cost);
        }
        if (bestSupply.col <= 0)
        {
            MarketData.supplys.RemoveAt(index);
        }
        else
        {
            MarketData.supplys[index] = bestSupply;
        }

        return true;
    }

    int BestSuply()
    {
        int[] sum = new int[MarketData.supplys.Count];
        float cost = 0.3f;
        float power = 0.4f;
        float speed = 0.4f;

        for (int i = 0; i < MarketData.supplys.Count; i++)
        {
            sum[i] += (int)(MarketData.supplys[i].loco.power * power);
            sum[i] += (int)(MarketData.supplys[i].loco.speed * speed);
            sum[i] -= (int)(MarketData.supplys[i].cost * cost / 100);
        }

        int max = 0;
        int index = 0;
        for (int i = 0; i < sum.Length; i++)
        {
            if (sum[i] > max)
            {
                max = sum[i];
                index = i;
            }
        }
        return index;
    }
}
