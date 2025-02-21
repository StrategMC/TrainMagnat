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
            Line.demandController.AddDemand(Line, Line.needLoc- Line.Locomotives.Count);
        }
        for (int i = 0; i < Line.Locomotives.Count; i++)
        {
            Line.Locomotives[i].ostalos--;
            if(Line.Locomotives[i].ostalos==0)
            {
                Line.Locomotives.RemoveAt(i);   
            }
        }
    }

    int NugnoParovozov()
    {
        return Line.kilometrag / 20;
    }
}
