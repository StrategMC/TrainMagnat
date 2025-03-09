using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class CompanyController : MonoBehaviour, IWeeklyUpdate
{
    public List<CompanyData> Companies;
    public DemandController DemandController;

    void Awake()
    {
        if (PlayerPrefs.GetInt("Load") == 0)
        {
            Companies = new List<CompanyData>();

            //��������
            CompanyData company1 = new CompanyData("����");
            CompanyData company2 = new CompanyData("����� � ������");
            CompanyData company3 = new CompanyData("��������");
            CompanyData company4 = new CompanyData("���������� \"����\"");
            CompanyData company5 = new CompanyData("�������");
            Companies.Add(company1);
            Companies.Add(company2);
            Companies.Add(company3);
            Companies.Add(company4);
            Companies.Add(company5);
        }
    }

    public void WeekTick()
    {
        foreach(CompanyData company in Companies)
        {
            int procent = UnityEngine.Random.Range(1, 100);
            if (procent < 20)
            {
                //������
            }
            else if (procent < 97)
            {
                int index = UnityEngine.Random.Range(0, company.Lines.Count);
                company.Lines[index].kilometrag = AddKilometragLine(company,company.Lines[index]);
            }
            else
            {
                LineData line = new LineData(company.Name,AvverageKilometrag(company));
                company.Lines.Add(line);
            }
            foreach(var line in company.Lines)
            {
                line.needLoc = NeedLocomotive(line);
                if (line.Locomotives.Count < line.needLoc)
                {
                    DemandController.AddDemand(line, line.needLoc - line.Locomotives.Count);
                }

                for (int i = line.Locomotives.Count - 1; i >= 0; i--)
                {
                    line.Locomotives[i].ostalos--;

                    if (line.Locomotives[i].ostalos == 0)
                    {
                        CompanyLocomotiveData locoToDestroy = line.Locomotives[i];
                        line.Locomotives.RemoveAt(i);
                    }
                }
            }
        }
    }
    private int AvverageKilometrag(CompanyData company)
    {
        int average = 0;
        for (int i = 0; i < company.Lines.Count; i++)
        {
            average += company.Lines[i].kilometrag;
        }
        average = average / company.Lines.Count;
        return average;
    }
    private int AddKilometragLine(CompanyData company, LineData line)
    {
        int average = 0;
        for (int i = 0; i < company.Lines.Count; i++)
        {
            average += company.Lines[i].kilometrag;
        }
        average = average / company.Lines.Count;
        line.kilometrag += average / 100 * UnityEngine.Random.Range(0, 15);
        return line.kilometrag;
    }
    private int NeedLocomotive(LineData line)
    {
        //���� ���� ����� ������� ���, �� ��������� ����������� ����������� ��������� ������� �� ������������� ������: 1 ������� 100 ��\� 40 ��, 1 50 ��\� 20 ��.
        return line.kilometrag / 20;
    }
}
