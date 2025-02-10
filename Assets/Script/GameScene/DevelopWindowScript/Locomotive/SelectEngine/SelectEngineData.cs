using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEngineData : MonoBehaviour
{
    public string Name;
    public int Size;
    public int Power;
    public int Ves;
    public int Different;
    public void Inicialize(string name,int size,int power, int ves, int different)
    {
        Name = name;
        Size = size;
        Power = power;
        Different = different;
        Ves = ves;
        Different = different;
    }
}
