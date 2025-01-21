using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour, IWeeklyUpdate
{
    public LineData Line; 

    public void WeekTick()
    {
        if (Line.Locomotives.Count < NugnoParovozov())
        {
            //купить паровозы на рынке(будет сделано после конструктора паровозов)
        }
        for (int i = 0; i < Line.Locomotives.Count; i++)
        {
            Line.Locomotives[i].ostalos--;
        }
    }

    int NugnoParovozov()
    {
        return Line.kilometrag / 20;
    }
}
