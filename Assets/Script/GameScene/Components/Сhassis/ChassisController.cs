using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChassisController : MonoBehaviour
{
    public ChassisData data;
    public void AdddChassi(string name, int size, int power, int ves, int difficulties)
    {
        Chassi chassi = new Chassi(name, size, power, ves, difficulties);
        data.chassis.Add(chassi);
    }
}
