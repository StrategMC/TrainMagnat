using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToMarketController : MonoBehaviour
{
    public MarketData marketData;
    public MarketView marketView;
    public SkladController skladController;
    public void AddToMarket(Locomotiew loco, int cost, int count)
    {
        if (Sodergit(loco))
        {
            Supply sup = new Supply("Player", loco, count, cost);
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
        Debug.Log("1");
        skladController.MinusPoezda(loco, count);
        marketView.PredlogenieView();
    }

    private bool Sodergit(Locomotiew loco)
    {
        if (marketData != null && marketData.supplys != null)
        {
            for (int i = 0; i < marketData.supplys.Count; i++)
            {
                if ( loco.name == marketData.supplys[i].loco.name)
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
}
