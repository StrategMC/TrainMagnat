using GlabalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchController : MonoBehaviour, IYearsUpdate, IWeeklyUpdate
{
    public ReasearchData reasearchData;
    public TimeData timeData;
    public ReasearchBonus reasearchBonus;

    void Start()
    {
        

        Technology texSteam = new Technology($"Паровая установка {timeData.year}", 30, 0, false, 5, 0, 0, 0, 0, 0);
        Technology texShasi = new Technology($"Механизмы шасси {timeData.year}", 30, 0, false, 0, 5, 0, 0, 0, 0);
        Technology texEko = new Technology($"Снижение массы шасси {timeData.year}", 32, 0, false, 0, 0, 5, 0, 0, 0);
        Technology texEkoEng = new Technology($"Снижение массы двигателя {timeData.year}", 32, 0, false, 0, 0, 0, 5, 0, 0);
        Technology texEngK = new Technology($"Новая конструкция двигателя {timeData.year}", 40, 0, false, 15, 0, 5, 0, 10, 0);
        Technology texShaK = new Technology($"Новая конструкция шасси {timeData.year}", 40, 0, false, 0, 15, 0, 5, 0, 10);

        reasearchData.technologys.Add(texSteam);
        reasearchData.technologys.Add(texShasi);
        reasearchData.technologys.Add(texEko);
        reasearchData.technologys.Add(texEkoEng);
        reasearchData.technologys.Add(texEngK);
        reasearchData.technologys.Add(texShaK);
       
    }

    public void YearsTick()
    {
        Technology texSteam = new Technology($"Паровая установка {timeData.year}", 30 * (timeData.year - 1829) / 10, 0, false, 5, 0, 0, 0, 0, 0);
        Technology texShasi = new Technology($"Механизмы шасси {timeData.year}", 30 * (timeData.year - 1829) / 10, 0, false, 0, 5, 0, 0, 0, 0);
        Technology texEko = new Technology($"Снижение массы шасси {timeData.year}", 32 * (timeData.year - 1829) / 10, 0, false, 0, 0, 5, 0, 0, 0);
        Technology texEkoEng = new Technology($"Снижение массы двигателя {timeData.year}", 32 * (timeData.year - 1829) / 10, 0, false, 0, 0, 0, 5, 0, 0);
        Technology texEngK = new Technology($"Новая конструкция двигателя {timeData.year}", 40 * (timeData.year - 1829) / 10, 0, false, 15, 0, 5, 0, 10, 0);
        Technology texShaK = new Technology($"Новая конструкция шасси {timeData.year}", 40 * (timeData.year - 1829) / 10, 0, false, 0, 15, 0, 5, 0, 10);

        reasearchData.technologys.Add(texSteam);
        reasearchData.technologys.Add(texShasi);
        reasearchData.technologys.Add(texEko);
        reasearchData.technologys.Add(texEkoEng);
        reasearchData.technologys.Add(texEngK);
        reasearchData.technologys.Add(texShaK);
    }

    public void WeekTick()
    {
        if (reasearchData.SelectResearch < reasearchData.technologys.Count)
        {
            var selectedResearch = reasearchData.technologys[reasearchData.SelectResearch];

            selectedResearch.need += reasearchData.point;

            if (selectedResearch.need >= selectedResearch.cost)
            {
                selectedResearch.done = true;
                reasearchBonus.PowerEngine += selectedResearch.PowerEngine;
                reasearchBonus.KPDShasi += selectedResearch.KPDShasi;
                reasearchBonus.VesShasi += selectedResearch.VesShasi;
                reasearchBonus.VesEngine += selectedResearch.VesEngine;
                reasearchBonus.SlognostEngine += selectedResearch.SlognostEngine;
                reasearchBonus.SlognostShasi += selectedResearch.SlognostShasi;

                reasearchData.technologys[reasearchData.SelectResearch] = selectedResearch;

             
                reasearchData.SelectResearch++;

                if (reasearchData.SelectResearch < reasearchData.technologys.Count)
                {
                    selectedResearch = reasearchData.technologys[reasearchData.SelectResearch];
                }
                else
                {
                    Debug.Log("Все исследования завершены.");
                }
            }
            else
            {
                reasearchData.technologys[reasearchData.SelectResearch] = selectedResearch;
            }
        }
        else
        {
            Debug.Log("Нет доступных исследований для выполнения.");
        }




    }
}

