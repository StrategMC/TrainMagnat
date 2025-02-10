using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChassisData : MonoBehaviour
{
    public string Name;
    public int Size;
    public int bonus;
    public int Ves;
    public int Different;
    public void Inicialize(string name, int size, int bonus, int ves, int different)
    {
        Name = name;
        Size = size;
        this.bonus = bonus;
        Ves = ves;
        Different = different;
    }
}
