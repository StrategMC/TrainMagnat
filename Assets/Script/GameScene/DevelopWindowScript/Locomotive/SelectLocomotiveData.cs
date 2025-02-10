using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLocomotiveData : MonoBehaviour
{
    public int Power;
    public int Speed;
    public int Cost;
    public void Inicialization(int power, int speed, int cost)
    {
        Power = power;
        Speed = speed;
        Cost = cost;
    }
}
