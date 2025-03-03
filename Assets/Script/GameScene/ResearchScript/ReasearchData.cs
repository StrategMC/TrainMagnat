using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasearchData 
{
    public int point;
    public List<Technology> technologys;
    public List<RedyTechnology> Redytechnologys;
    public ReasearchData()
    {
        technologys = new List<Technology>();
        Redytechnologys= new List<RedyTechnology>();
    }
}
public struct RedyTechnology
{
    public string name;
    public RedyTechnology(string name)
    {
        this.name = name;
    }
}
    public struct Technology
{
    public string name;
    public int cost;
    public int need;
    public int PowerEngine;
    public int KPDShasi;
    public int VesShasi;
    public int VesEngine;
    public int SlognostEngine;
    public int SlognostShasi;

    public Technology(string name, int cost, int need,  int PowerEngine, int KPDShasi, int VesShasi, int VesEngine, int SlognostEngine, int SlognostShasi)
    {
        this.name = name;
        this.cost = cost;
        this.need = need;
        this.PowerEngine = PowerEngine;
        this.KPDShasi = KPDShasi;
        this.VesShasi = VesShasi;
        this.VesEngine = VesEngine;
        this.SlognostEngine = SlognostEngine;
        this.SlognostShasi = SlognostShasi;
    }
}

