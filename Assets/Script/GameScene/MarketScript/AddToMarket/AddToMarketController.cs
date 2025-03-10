using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToMarketController : MonoBehaviour
{
    public DemandController demandController;
    public MarketView marketView;
    public SkladController skladController;
    public void AddToMarket(Locomotiew loco, int cost, int count)
    {
        if (Sodergit(loco))
        {
            Supply sup = new Supply("Player", loco, count, cost);
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
        //Debug.Log("1");
        skladController.MinusPoezda(loco, count);
        //marketView.PredlogenieView();
    }

    private bool Sodergit(Locomotiew loco)
    {
        if (demandController.MarketData != null && demandController.MarketData.supplys != null)
        {
            for (int i = 0; i < demandController.MarketData.supplys.Count; i++)
            {
                if ( loco.name == demandController.MarketData.supplys[i].loco.name)
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            Debug.LogWarning("marketData ��� marketData.supplys �� ����������������.");
            return false;
        }
    }
}
