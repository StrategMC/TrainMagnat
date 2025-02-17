using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineData : MonoBehaviour
{
    public string Name;
    public int kilometrag;
    public int needLoc;
    public List<CompanyLocomotiveData> Locomotives;
    public DemandController demandController;
    public LineController lineController; 
    
    void Awake()
    {
        Locomotives = new List<CompanyLocomotiveData>();
        lineController = gameObject.AddComponent<LineController>(); 
        lineController.Line = this; 
    }
    
    public void Initialize(string name, int kilometrage, DemandController demandController)
    {
        this.Name = name;
        this.kilometrag = kilometrage;
        this.demandController = demandController;
    }
}

