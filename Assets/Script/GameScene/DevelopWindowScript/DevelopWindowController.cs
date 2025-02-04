using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopWindowController : MonoBehaviour
{
    public DevelopWindowData data; 

    public void Obnova()
    {
        switch (data.lvlFinans)
        {
            case 1:
                data.Rashod = 1000;
                data.bonus = -15;
                break;
            case 2:
                data.Rashod = 5000;
                data.bonus = -5;
                break;
            case 3:
                data.Rashod = 10000;
                data.bonus = 5;
                break;
            case 4:
                data.Rashod = 20000;
                data.bonus = 15;
                break;
            case 5:
                data.Rashod = 50000;
                data.bonus = 30;
                break;
            case 6:
                data.Rashod = 100000;
                data.bonus = 50;
                break;
            case 7:
                data.Rashod = 150000;
                data.bonus = 100;
                break;
        }
    }
}
