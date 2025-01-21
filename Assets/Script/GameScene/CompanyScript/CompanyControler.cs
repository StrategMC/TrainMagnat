using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class CompanyController : MonoBehaviour, IWeeklyUpdate
{
    public CompanyData Company;

    void Start()
    {
        Company = GetComponent<CompanyData>();
        if (Company == null)
        {
            Debug.LogError("CompanyData не найдено!");
        }
    }

    public void WeekTick()
    {
        int procent = UnityEngine.Random.Range(1, 100);
        if (procent < 20)
        {
            //ничего
        }
        else if (procent < 97)
        {
            int index = UnityEngine.Random.Range(0, Company.Lines.Count);
            Company.Lines[index].kilometrag = AddKilometragLine(Company.Lines[index]);
        }
        else
        {
            GameObject lineObject = new GameObject($"Line{Company.Lines.Count + 1}");
            lineObject.transform.parent = this.transform;
            LineData newLine = lineObject.AddComponent<LineData>();
            newLine.Initialize($"{Company.Name} Линия {Company.Lines.Count + 1}", AvverageKilometrag());
            Company.Lines.Add(newLine);
        }
    }
    private int AvverageKilometrag()
    {
        int average = 0;
        for (int i = 0; i < Company.Lines.Count; i++)
        {
            average += Company.Lines[i].kilometrag;
        }
        average = average / Company.Lines.Count;
        return average;
    }
    private int AddKilometragLine(LineData line)
    {
        int average = 0;
        for (int i = 0; i < Company.Lines.Count; i++)
        {
            average += Company.Lines[i].kilometrag;
        }
        average = average / Company.Lines.Count;
        line.kilometrag += average / 100 * UnityEngine.Random.Range(0, 15);
        return line.kilometrag;
    }
}
