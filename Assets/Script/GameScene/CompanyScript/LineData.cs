using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineData : MonoBehaviour
{
    public string Name;
    public int kilometrag;
    public List<CompanyLocomotiveData> Locomotives;
    public LineController lineController; 
    
    void Awake()
    {
        Locomotives = new List<CompanyLocomotiveData>();
        lineController = gameObject.AddComponent<LineController>(); 
        lineController.Line = this; 
    }
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject locomotiveObject = new GameObject($"Locomotive");
            locomotiveObject.transform.parent = this.transform;
            CompanyLocomotiveData locoData = locomotiveObject.AddComponent<CompanyLocomotiveData>();
            locoData.Initialize($"Паровозик", 10);
            Locomotives.Add(locoData);
        }
    }
    public void Initialize(string name, int kilometrage)
    {
        this.Name = name;
        this.kilometrag = kilometrage;
    }
}

