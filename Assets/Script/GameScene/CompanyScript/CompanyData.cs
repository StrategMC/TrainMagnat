using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyData : MonoBehaviour
{
    public string Name;
    public List<LineData> Lines = new List<LineData>();

    public DemandController DemandController;

    public CompanyData()
    {
        Name = "�������� ��������";
        Lines = new List<LineData>();
    }

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject lineObject = new GameObject($"Line{i + 1}");
            lineObject.transform.parent = this.transform; 
            LineData lineData = lineObject.AddComponent<LineData>(); 
            lineData.Initialize($"{Name} ����� {Lines.Count + 1}", 100, DemandController);
            Lines.Add(lineData);
        }
    }
}

