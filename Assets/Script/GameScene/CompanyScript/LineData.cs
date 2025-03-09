using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineData
{
    public string Name;
    public int kilometrag;
    public int needLoc;
    public List<CompanyLocomotiveData> Locomotives;

    
    public LineData(string name, int kilometrage)
    {
        this.Name = name;
        this.kilometrag = kilometrage;
        Locomotives = new List<CompanyLocomotiveData>();
    }
}

