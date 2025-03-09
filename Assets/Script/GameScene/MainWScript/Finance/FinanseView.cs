using UnityEngine;
using UnityEngine.UI;
public class FinanseView : MonoBehaviour
{
    public FinanseViewData data;
    public Text ProfitForLocomotiveSellText;
    public Text ÑonsumptionForProductionText;
    public Text ConsumptionForResearchText;
    public Text ConsumptionForDevelopText;

  
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Load") == 0)
        {
            data = new FinanseViewData();
        }
        ÑonsumptionForProductionText.text = $"{data.lastconsumptionforproduction}$";
        ConsumptionForResearchText.text = $"{data.lastconsumptionforresearch}$";
        ConsumptionForDevelopText.text = $"{data.lastconsumptionfordevelop}$";
        ProfitForLocomotiveSellText.text = $"{data.lastprofitforlocomotievesell}$";

    }

    //private int lastWeekConsumptionProduction;
    //private int lastWeekConsumptionResearch;
    //private int lastWeekConsumptionDevelop;


    public void View()
    {
        data.lastprofitforlocomotievesell= data.profitforlocomotievesell;
        data.lastconsumptionforproduction= data.consumptionforproduction;
        data.lastconsumptionforresearch = data.consumptionforresearch;
        data.lastconsumptionfordevelop = data.consumptionfordevelop;
    
        
        ÑonsumptionForProductionText.text = $"{data.consumptionforproduction}$";
        ConsumptionForResearchText.text = $"{data.consumptionforresearch}$";
        ConsumptionForDevelopText.text = $"{data.consumptionfordevelop}$";
        ProfitForLocomotiveSellText.text = $"{data.profitforlocomotievesell}$";

        data.profitforlocomotievesell = 0;
        data.consumptionforproduction = 0;
        data.consumptionforresearch = 0;
        data.consumptionfordevelop = 0;
    }

   
}
