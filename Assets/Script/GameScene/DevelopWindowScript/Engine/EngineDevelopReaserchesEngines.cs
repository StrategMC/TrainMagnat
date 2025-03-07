using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EngineDevelopReaserchesEngines : MonoBehaviour, IWeeklyUpdate
{
    public EhineController engineController;
    public DevelopWindowController developWindowController;
    public EngineDevelopReaserchesEnginesData dataRes;

    public Image ProgressBar;
    public Text TextProcent;
    public void Start()
    {
        dataRes=new EngineDevelopReaserchesEnginesData();
        if (dataRes.active == true)
        {
            View();
        }
    }
    public void Vyzov(string name, int size, int power, int ves, int difficulties,float timeReasearch)
    {
        dataRes.active = true;
        dataRes.name = name;
        dataRes.size = size;
        dataRes.power = power;
        dataRes.ves = ves;
        dataRes.difficulties = difficulties;
        dataRes.timeResearch = timeReasearch;
        dataRes.reaserches = 0;
        View();
    }
    public void View()
    {
        ProgressBar.fillAmount = dataRes.reaserches / dataRes.timeResearch;
        TextProcent.text = $"{dataRes.reaserches}/{dataRes.timeResearch} ОИ";
    }
    public void WeekTick()
    {
        if (dataRes.active)
        {
            dataRes.reaserches = dataRes.reaserches + developWindowController.data.bonus;
            View();
            if (dataRes.reaserches >= dataRes.timeResearch)
            {
                engineController.AddEngine(dataRes.name, dataRes.size, dataRes.power, dataRes.ves, dataRes.difficulties);
                TextProcent.text = $"Готово";
                ProgressBar.fillAmount = 1;
                dataRes.active = false;
            }
        }
        else
        {
            TextProcent.text = $"Не разрабатывается";
            ProgressBar.fillAmount = 0;
        }
    }
}
