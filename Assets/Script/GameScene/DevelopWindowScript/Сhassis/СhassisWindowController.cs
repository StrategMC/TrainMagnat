using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class СhassisWindowController : MonoBehaviour
{
    public СhassisWindowView view;
    public СhassisWindowData data;
    public ResearchController researchController;
    public void Start()
    {
        PodschetSvoistv();
    }

    public void PodschetSvoistv()
    {
        ReasearchBonus bonus = researchController.researchBonus;
        //Место под двигатель
        int tempPlace = data.placeE + data.place-1;
        switch(tempPlace)
        {
            case 1:
                data.placeEngine = 1;
                break;
            case 2:
                data.placeEngine = 2;
                break;
            case 3:
            case 4:
                data.placeEngine = 3;
                break;
            default:
                data.placeEngine = 0;
                break;
        }
        //бонус к кпд
        data.bonusKPD = 0;
        data.bonusKPD += (int)(data.bonusKPD * (bonus.KPDShasi / 100f));
        data.bonusKPD += data.hodovaa * 5;
        data.bonusKPD += data.technologi * 5; 
        //Вес
        data.ves = 5000;
        data.ves -= (int)(data.ves * (bonus.VesShasi / 100f));
        data.ves += (int)(data.ves * (data.place * 10 / 100f));
        //Сложность
        data.difficult = 150;
        data.difficult += (int)(data.technologi * 15);
        data.difficult += (int)(data.placeE * 5);
        data.difficult += (int)(data.place * 10);
        data.difficult += (int)(data.hodovaa * 10);
        //Очков разработки
        data.point = 10;
        data.point += data.place;
        data.point += data.placeE;
        data.point += data.technologi;
        data.point += data.hodovaa;
        //Денег на разработку
        data.money = 10000;
        data.money += data.place*1000;
        data.money += data.placeE * 1000;
        data.money += data.technologi * 1000;
        data.money += data.hodovaa * 1000;
        view.ViewSvoistva();
    }
    
}
