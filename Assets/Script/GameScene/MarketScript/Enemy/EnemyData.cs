using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    public string name;
    public List<Locomotiew> locomotiews;
    public EnemyData(string name)
    {
        this.name = name;
        locomotiews = new List<Locomotiew>();
    }
}
