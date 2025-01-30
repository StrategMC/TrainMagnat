using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasearchData : MonoBehaviour
{
    public int point;
    public List<Technology> technologys;
    public int SelectResearch;
    private void Awake()
    {
        technologys = new List<Technology>();
    }
}
public struct Technology
{
    public string name;
    public int cost;
    public int need;
    public bool done;
    public int PowerEngine;
    public int KPDShasi;
    public int VesShasi;
    public int VesEngine;
    public int SlognostEngine;
    public int SlognostShasi;

    public Technology(string name, int cost, int need, bool done, int PowerEngine, int KPDShasi, int VesShasi, int VesEngine, int SlognostEngine, int SlognostShasi)
    {
        this.name = name;
        this.cost = cost;
        this.need = need;
        this.done = done;
        this.PowerEngine = PowerEngine;
        this.KPDShasi = KPDShasi;
        this.VesShasi = VesShasi;
        this.VesEngine = VesEngine;
        this.SlognostEngine = SlognostEngine;
        this.SlognostShasi = SlognostShasi;
    }
}

