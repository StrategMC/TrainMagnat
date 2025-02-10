using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotiveData : MonoBehaviour
{
   public List<Locomotiew> locomotiews=new List<Locomotiew>();
}
public struct Locomotiew
{
    public string name;
    public int speed;
    public int power;
    public int cost;
    public Locomotiew(string name, int speed, int power, int cost)
    {
        this.name = name;
        this.speed = speed;
        this.power = power;
        this.cost = cost;
    }
}