using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IWeeklyUpdate, IYearsUpdate
{
    public List<EnemyData> enemies;
    public DemandController demandController;
    public MarketView marketView;
    public void Awake()
    {
        if (PlayerPrefs.GetInt("Load") == 0)
        {
            enemies = new List<EnemyData>();
            EnemyData enemy1 = new EnemyData("Аркадий");
            EnemyData enemy2 = new EnemyData("Паровозов");
            enemies.Add(enemy1);
            enemies.Add(enemy2);
            foreach (EnemyData enemy in enemies)
            {
                Locomotiew loco = new Locomotiew($"{enemy.name} 1", Random.Range(50, 70), 70, 1);
                enemy.locomotiews.Add(loco);
            }
        }
       

    }
    public void WeekTick()
    {
        foreach (EnemyData enemy in enemies)
        {
            AddToMarket(enemy.locomotiews[enemy.locomotiews.Count - 1], Random.Range(1000, 7000), Random.Range(1, 10));
        }
    }
    public void AddToMarket(Locomotiew loco, int cost, int count)
    {
        if (Sodergit(loco))
        {
            Supply sup = new Supply("Enemy", loco, count, cost);
            demandController.MarketData.supplys.Add(sup);
        }
        else
        {
            for (int i = 0; i < demandController.MarketData.supplys.Count; i++)
            {
                if (loco.name == demandController.MarketData.supplys[i].loco.name)
                {
                    demandController.MarketData.supplys[i] = new Supply(demandController.MarketData.supplys[i].CompanyName, demandController.MarketData.supplys[i].loco, demandController.MarketData.supplys[i].col + count, cost);
                }
            }
        }
       // marketView.PredlogenieView();
    }
    private bool Sodergit(Locomotiew loco)
    {
        if (demandController.MarketData != null && demandController.MarketData.supplys != null)
        {
            for (int i = 0; i < demandController.MarketData.supplys.Count; i++)
            {
                if (loco.name == demandController.MarketData.supplys[i].loco.name)
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
        foreach (EnemyData enemy in enemies)
        {
            Locomotiew loco = new Locomotiew($"{enemy.name} 2", Random.Range(60, 80), 90, 1);
            enemy.locomotiews.Add(loco);
        }
    }
}
