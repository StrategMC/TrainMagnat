using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChassisWindowReaserch : MonoBehaviour, IWeeklyUpdate
{
    public ChassisController controller;
    public DevelopWindowData data;

    public bool active = false;
    public string name;
    public int size;
    public int bonusKpd;
    public int ves;
    public int difficulties;

    public float necessaryReasearchPoint;
    public float haveReasearchPoint;

    public Image ProgressBar;
    public Text TextProcent;
    public void Vyzov(string name, int size, int bonus, int ves, int difficulties, float necessaryReasearchPoint)
    {
        active = true;
        this.name = name;
        this.size = size;
        this.bonusKpd = bonus;
        this.ves = ves;
        this.difficulties = difficulties;
        this.necessaryReasearchPoint = necessaryReasearchPoint;
        haveReasearchPoint = 0;
        ProgressBar.fillAmount = haveReasearchPoint / necessaryReasearchPoint;
        TextProcent.text = $"{haveReasearchPoint}/{necessaryReasearchPoint} ОИ";
    }

    public void WeekTick()
    {
        if (active)
        {
            haveReasearchPoint += data.bonus;
            ProgressBar.fillAmount= haveReasearchPoint /necessaryReasearchPoint ;
            TextProcent.text = $"{haveReasearchPoint}/{necessaryReasearchPoint} ОИ";
            if(haveReasearchPoint>=necessaryReasearchPoint)
            {
                controller.AdddChassi(name,size,bonusKpd,ves,difficulties);
                TextProcent.text = $"Готово";
                ProgressBar.fillAmount = 1;
                active = false;
            }
        }
        else
        {
            TextProcent.text = "Не разрабатывается";
            ProgressBar.fillAmount = 0f;
        }
    }
}
