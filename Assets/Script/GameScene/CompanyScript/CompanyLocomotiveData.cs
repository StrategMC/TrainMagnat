using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyLocomotiveData : MonoBehaviour
{
    public string Name;
    public int ostalos;
    public void Initialize(string name,int ostalos)
    {
        Name=name;
        this.ostalos = ostalos;
    }
}
