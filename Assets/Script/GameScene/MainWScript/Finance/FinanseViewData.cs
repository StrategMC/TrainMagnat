using UnityEngine;
using UnityEngine.UI;
public class FinanseViewData
{
    public int profitforlocomotievesell;
    public int consumptionforproduction;
    public int consumptionforresearch;
    public int consumptionfordevelop;

    public int lastprofitforlocomotievesell;
    public int lastconsumptionforproduction;
    public int lastconsumptionforresearch;
    public int lastconsumptionfordevelop;
    public FinanseViewData()
    {
       profitforlocomotievesell = 0;
       consumptionforproduction = 0;
       consumptionforresearch = 0;
       consumptionfordevelop=0;
    }
}
