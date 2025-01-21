using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanyView : MonoBehaviour
{
    public GameObject companyButtonPrefab;
    public Transform buttonParent; 
    

    private List<CompanyData> companies;

    void Start()
    {
        companies = new List<CompanyData>(FindObjectsOfType<CompanyData>());

        foreach (CompanyData company in companies)
        {
            GameObject button = Instantiate(companyButtonPrefab, buttonParent);
            button.GetComponentInChildren<Text>().text = company.Name;
            //button.GetComponent<Button>().onClick.AddListener(() => OnCompanyButtonClicked(company));
        }
    }

    
}
