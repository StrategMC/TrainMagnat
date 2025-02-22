using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IWeeklyUpdate, IYearsUpdate
{
    public EnemyData enemyData;
    public MarketData marketData;
    public MarketView marketView;
    public void Start()
    {
        Locomotiew loco= new Locomotiew($"{enemyData.name} 1", Random.Range(50,70),70,1);
        enemyData.locomotiews.Add(loco);
    }
    public void WeekTick()
    {
        AddToMarket(enemyData.locomotiews[enemyData.locomotiews.Count - 1], Random.Range(1000, 7000), Random.Range(1, 10));
    }
    public void AddToMarket(Locomotiew loco, int cost, int count)
    {
        if (Sodergit(loco))
        {
            Supply sup = new Supply("Enemy", loco, count, cost);
            marketData.supplys.Add(sup);
        }
        else
        {
            for (int i = 0; i < marketData.supplys.Count; i++)
            {
                if (loco.name == marketData.supplys[i].loco.name)
                {
                    marketData.supplys[i] = new Supply(marketData.supplys[i].CompanyName, marketData.supplys[i].loco, marketData.supplys[i].col + count, cost);
                }
            }
        }
        marketView.PredlogenieView();
    }
    private bool Sodergit(Locomotiew loco)
    {
        if (marketData != null && marketData.supplys != null)
        {
            for (int i = 0; i < marketData.supplys.Count; i++)
            {
                if (loco.name == marketData.supplys[i].loco.name)
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            Debug.LogWarning("marketData или marketData.supplys не инициализированы.");
            return false;
        }
    }
    public void YearsTick()
    {
        Locomotiew loco = new Locomotiew($"{enemyData.name} 2", Random.Range(60, 80), 90, 1);
        enemyData.locomotiews.Add(loco);
    }
}
