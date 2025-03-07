using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChassisWindowReaserch : MonoBehaviour, IWeeklyUpdate
{
    public ChassisController controller;
    public DevelopWindowController developWindowController;

    public ChassisWindowReaserchData dataRes;

    public Image ProgressBar;
    public Text TextProcent;
    void Start()
    {
        dataRes = new ChassisWindowReaserchData();
        if (dataRes.active==true)
        {
        }
    }
    public void Vyzov(string name, int size, int bonus, int ves, int difficulties, float necessaryReasearchPoint)
    {
        dataRes.active = true;
        dataRes.name = name;
        dataRes.size = size;
        dataRes.bonusKpd = bonus;
        dataRes.ves = ves;
        dataRes.difficulties = difficulties;
        dataRes.necessaryReasearchPoint = necessaryReasearchPoint;
        dataRes.haveReasearchPoint = 0;
        View();
    }
    void View()
    {
        ProgressBar.fillAmount = dataRes.haveReasearchPoint / dataRes.necessaryReasearchPoint;
        TextProcent.text = $"{dataRes.haveReasearchPoint}/{dataRes.necessaryReasearchPoint} ОИ";
    }
    public void WeekTick()
    {
        if (dataRes.active)
        {
            dataRes.haveReasearchPoint += developWindowController.data.bonus;
            View();
            if(dataRes.haveReasearchPoint >= dataRes.necessaryReasearchPoint)
            {
                controller.AdddChassi(dataRes.name, dataRes.size, dataRes.bonusKpd, dataRes.ves, dataRes.difficulties);
                TextProcent.text = $"Готово";
                ProgressBar.fillAmount = 1;
                dataRes.active = false;
            }
        }
        else
        {
            TextProcent.text = "Не разрабатывается";
            ProgressBar.fillAmount = 0f;
        }
    }
}
