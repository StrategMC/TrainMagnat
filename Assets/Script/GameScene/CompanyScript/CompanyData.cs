using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyData
{
    public string Name;
    public List<LineData> Lines = new List<LineData>();

    public CompanyData(string name)
    {
        Name = name;
        Lines = new List<LineData>();
        for (int i = 0; i < 2; i++)
        {
            LineData line = new LineData($"{Name} {i + 1}", 100);
            Lines.Add(line);    
        }
    }
}

