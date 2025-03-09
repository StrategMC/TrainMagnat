using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketData
{
   public List<Supply> supplys=new List<Supply>();
   public List<Demand> demands=new List<Demand> ();
}
public struct Supply
{
    public string CompanyName;
    public Locomotiew loco;
    public int col;
    public int cost;
    public Supply(string CompanyName, Locomotiew loco, int col, int cost)
    {
        this.CompanyName = CompanyName;
        this.loco = loco;
        this.col = col;
        this.cost = cost;
    }
}
public struct Demand
{
    public LineData line;
    public int col;
    public Demand(LineData line, int col)
    {
        this.line = line;
        this.col = col;
    }
}
