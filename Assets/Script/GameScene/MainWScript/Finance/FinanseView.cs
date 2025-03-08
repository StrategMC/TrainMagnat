using UnityEngine;
using UnityEngine.UI;
public class FinanseView : MonoBehaviour
{
    public FinanseViewData data;
    public Text ProfitForLocomotiveSellText;
    public Text ÑonsumptionForProductionText;
    public Text ConsumptionForResearchText;
    public Text ConsumptionForDevelopText;

    private void Start()
    {
        data=new FinanseViewData();

        View();
    }

    //private int lastWeekConsumptionProduction;
    //private int lastWeekConsumptionResearch;
    //private int lastWeekConsumptionDevelop;


    public void View()
    {
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
