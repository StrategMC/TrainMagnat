using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotiveController : MonoBehaviour
{
    public LocomotiveData data;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Load") == 0)
        {
            data = new LocomotiveData();
        }
    }
    public void AddLocomotiev(string name, int speeed, int power, int difficult)
    {
       
        Locomotiew locomotiew = new Locomotiew(name,speeed, power, difficult);
        data.locomotiews.Add(locomotiew);
    }
}
