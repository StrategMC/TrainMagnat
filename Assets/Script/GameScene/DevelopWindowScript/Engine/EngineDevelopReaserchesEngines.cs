using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EngineDevelopReaserchesEngines : MonoBehaviour, IWeeklyUpdate
{
    public EhineController engineController;
    public DevelopWindowData data;
    public bool active=false;
    public string name;
    public int size;
    public int power;
    public int ves;
    public int difficulties;

    public float timeResearch;
    public float reaserches;

    public Image ProgressBar;
    public Text TextProcent;
    public void Vyzov(string name, int size, int power, int ves, int difficulties,float timeReasearch)
    {
        active = true;
        this.name = name;
        this.size = size;
        this.power = power;
        this.ves = ves;
        this.difficulties = difficulties;
        this.timeResearch = timeReasearch;
        reaserches = 0;
        ProgressBar.fillAmount = reaserches / timeResearch;
        TextProcent.text = $"{reaserches}/{timeResearch} ОИ";
    }
    public void WeekTick()
    {
        if (active)
        {
            reaserches = reaserches+ data.bonus;
            ProgressBar.fillAmount = reaserches / timeResearch;
            TextProcent.text = $"{reaserches}/{timeResearch} ОИ";
            if (reaserches >= timeResearch)
            {
                engineController.AddEngine(name, size, power, ves, difficulties);
                TextProcent.text = $"Готово";
                ProgressBar.fillAmount = 1;
                active = false;
            }
        }
        else
        {
            TextProcent.text = $"Не разрабатывается";
            ProgressBar.fillAmount = 0;
        }
    }
}
