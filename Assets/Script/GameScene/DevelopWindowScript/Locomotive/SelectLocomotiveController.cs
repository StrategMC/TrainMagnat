using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLocomotiveController : MonoBehaviour
{
    public SelectChassisData SelectChassisData;
    public SelectEngineData SelectEngineData;
    public SelectLocomotiveData data;
    public void Podschet()
    {
        int ves=SelectChassisData.Ves+SelectEngineData.Ves;
        int speed = 20;
        speed += (int)(SelectEngineData.Power+SelectEngineData.Power * ((float)SelectChassisData.bonus / 100)/10);
        speed -= ves / 500;
        data.Speed=speed;
        data.Power = SelectEngineData.Power;
        data.Cost=SelectEngineData.Different+SelectChassisData.Different;
    }
}
