using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchController : MonoBehaviour, IYearsUpdate,IWeeklyUpdate
{
    ReasearchData reasearchData;
    void Start()
    {
        reasearchData=new ReasearchData();
    }
    public void YearsTick()
    {
        //���������� ����� ������������ ������� ���
    }
    public void WeekTick()
    {
        //������� ������������
    }
}
