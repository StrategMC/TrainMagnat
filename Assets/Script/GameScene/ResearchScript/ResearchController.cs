using GlabalGame;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResearchController : MonoBehaviour, IYearsUpdate, IWeeklyUpdate
{
    public ReasearchData reasearchData;
    public ResearchView researchView;
    public ResearchProgresBar Bar;
    public TimeData timeData;
    public ReasearchBonus reasearchBonus;

    void Start()
    {
        Technology texSteam = new Technology($"������� ��������� {timeData.year}", 30, 0, 5, 0, 0, 0, 0, 0);
        Technology texShasi = new Technology($"��������� ����� {timeData.year}", 30, 0, 0, 5, 0, 0, 0, 0);
        Technology texEko = new Technology($"�������� ����� ����� {timeData.year}", 32, 0, 0, 0, 5, 0, 0, 0);
        Technology texEkoEng = new Technology($"�������� ����� ��������� {timeData.year}", 32, 0, 0, 0, 0, 5, 0, 0);
        Technology texEngK = new Technology($"����� ����������� ��������� {timeData.year}", 40, 0, 15, 0, 5, 0, 10, 0);
        Technology texShaK = new Technology($"����� ����������� ����� {timeData.year}", 40, 0, 0, 15, 0, 5, 0, 10);

        reasearchData.technologys.Add(texSteam);
        reasearchData.technologys.Add(texShasi);
        reasearchData.technologys.Add(texEko);
        reasearchData.technologys.Add(texEkoEng);
        reasearchData.technologys.Add(texEngK);
        reasearchData.technologys.Add(texShaK);
        researchView.View();
    }
    public void PointUpdate(string tex)
    {
       int num = int.Parse(tex);
       reasearchData.point=num; 
    }
    public void MoveUp(int index)
    {
        if (index > 0 && index < reasearchData.technologys.Count)
        {
            var temp = reasearchData.technologys[index];
            reasearchData.technologys[index] = reasearchData.technologys[index - 1];
            reasearchData.technologys[index - 1] = temp;
            researchView.View();
        }
    }

    public void YearsTick()
    {
        Technology texSteam = new Technology($"������� ��������� {timeData.year}", 30 * (timeData.year - 1829) / 10, 0, 5, 0, 0, 0, 0, 0);
        Technology texShasi = new Technology($"��������� ����� {timeData.year}", 30 * (timeData.year - 1829) / 10, 0, 0, 5, 0, 0, 0, 0);
        Technology texEko = new Technology($"�������� ����� ����� {timeData.year}", 32 * (timeData.year - 1829) / 10, 0, 0, 0, 5, 0, 0, 0);
        Technology texEkoEng = new Technology($"�������� ����� ��������� {timeData.year}", 32 * (timeData.year - 1829) / 10, 0, 0, 0, 0, 5, 0, 0);
        Technology texEngK = new Technology($"����� ����������� ��������� {timeData.year}", 40 * (timeData.year - 1829) / 10, 0, 15, 0, 5, 0, 10, 0);
        Technology texShaK = new Technology($"����� ����������� ����� {timeData.year}", 40 * (timeData.year - 1829) / 10, 0, 0, 15, 0, 5, 0, 10);

        reasearchData.technologys.Add(texSteam);
        reasearchData.technologys.Add(texShasi);
        reasearchData.technologys.Add(texEko);
        reasearchData.technologys.Add(texEkoEng);
        reasearchData.technologys.Add(texEngK);
        reasearchData.technologys.Add(texShaK);
        researchView.View();
    }

    public void WeekTick()
    {
        if (reasearchData.technologys.Count > 0)
        {
            var selectedResearch = reasearchData.technologys[0];

            selectedResearch.need += reasearchData.point;

            if (selectedResearch.need >= selectedResearch.cost)
            {
                reasearchBonus.PowerEngine += selectedResearch.PowerEngine;
                reasearchBonus.KPDShasi += selectedResearch.KPDShasi;
                reasearchBonus.VesShasi += selectedResearch.VesShasi;
                reasearchBonus.VesEngine += selectedResearch.VesEngine;
                reasearchBonus.SlognostEngine += selectedResearch.SlognostEngine;
                reasearchBonus.SlognostShasi += selectedResearch.SlognostShasi;

                reasearchData.technologys[0] = selectedResearch;

                RedyTechnology Redy = new RedyTechnology(reasearchData.technologys[0].name);
                reasearchData.Redytechnologys.Add(Redy);
                reasearchData.technologys.Remove(reasearchData.technologys[0]);
                researchView.View();
                researchView.View2();
            }
            else
            {
                reasearchData.technologys[0] = selectedResearch;
            }
            Bar.Move();
        }
        else
        {
            Debug.Log("��� ��������� ������������ ��� ����������.");
        }
        researchView.ViewBonus();
    }
}