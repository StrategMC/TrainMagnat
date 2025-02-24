using UnityEngine;
using UnityEngine.UI;
public class FinanseView : MonoBehaviour
{
    public Text ProfitForLocomotiveSellText;
    public Text ÑonsumptionForProductionText;
    public Text ConsumptionForResearchText;
    public Text ConsumptionForDevelopText;

    public int profitforlocomotievesell;
    public int consumptionforproduction;
    public int consumptionforresearch;
    public int consumptionfordevelop;

    //private int lastWeekConsumptionProduction;
    //private int lastWeekConsumptionResearch;
    //private int lastWeekConsumptionDevelop;

  
    public void View()
    {
        ÑonsumptionForProductionText.text = $"{consumptionforproduction}$";
        ConsumptionForResearchText.text = $"{consumptionforresearch}$";
        ConsumptionForDevelopText.text = $"{consumptionfordevelop}$";
        ProfitForLocomotiveSellText.text = $"{profitforlocomotievesell}$";

        profitforlocomotievesell = 0;
        consumptionforproduction = 0;
        consumptionforresearch = 0;
        consumptionfordevelop = 0;
    }

   
}
