using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotiveController : MonoBehaviour
{
    public LocomotiveData data;
    public void AddLocomotiev(string name, int speeed, int power, int difficult)
    {
        Locomotiew locomotiew = new Locomotiew(name,speeed, power, difficult);
        data.locomotiews.Add(locomotiew);
    }
}
