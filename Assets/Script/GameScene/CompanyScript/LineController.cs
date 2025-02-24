using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour, IWeeklyUpdate
{
    public LineData Line;

    public void WeekTick()
    {
        Line.needLoc = NugnoParovozov();

        if (Line.Locomotives.Count < Line.needLoc)
        {
            Line.demandController.AddDemand(Line, Line.needLoc - Line.Locomotives.Count);
        }
        
        for (int i = Line.Locomotives.Count - 1; i >= 0; i--)
        {
            Line.Locomotives[i].ostalos--;

            if (Line.Locomotives[i].ostalos == 0)
            {
                CompanyLocomotiveData locoToDestroy = Line.Locomotives[i];

                Line.Locomotives.RemoveAt(i);

                Destroy(locoToDestroy.gameObject);
            }
        }
    }

    int NugnoParovozov()
    {
        return Line.kilometrag / 20;
    }
}
