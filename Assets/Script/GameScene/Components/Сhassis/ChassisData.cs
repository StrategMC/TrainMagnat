using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChassisData
{
    public List<Chassi> chassis;
    public ChassisData()
    {
        chassis = new List<Chassi>();
    }
}
public struct Chassi
{
    public string name;
    public int size;
    public int bonusKpd;
    public int ves;
    public int difficult;
    public Chassi(string name,int size, int bonusKpd, int ves, int difficult)
    {
        this.name = name;
        this.size = size;
        this.bonusKpd = bonusKpd;
        this.ves = ves;
        this.difficult = difficult;
    }
}
