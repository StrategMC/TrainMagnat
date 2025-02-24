using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItogView : MonoBehaviour
{
    public Text AllSellText;
    public Text AllPlayerSellText;
    public Text ProfitText;
    int allsell;
    int playersell;
    int profit;
    public void Init(int allsell, int playersell,int profit)
    {
       this.allsell = allsell;
       this.playersell = playersell;
       this.profit = profit;
    }
    public void View()
    {
        AllSellText.text = $"Продаж всего: {allsell}ед.";
        AllPlayerSellText.text = $"Ваших продаж: {playersell}ед.";
        ProfitText.text = $"Вы заработали {profit}$";
    }
}
