using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineData
{
    public List<Engine> engines;
    public EngineData()
    {
        engines = new List<Engine>();   
    }
}

public struct Engine
{
    public string name;
    public int size;
    public int power;
    public int ves;
    public int difficulties;
    public Engine(string name,int size,int power,int ves,int difficulties)
    {
        this.name = name;
        this.size = size;
        this.power = power;
        this.ves = ves;
        this.difficulties = difficulties;
    }

}