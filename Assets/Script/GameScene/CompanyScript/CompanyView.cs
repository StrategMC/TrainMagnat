using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanyView : MonoBehaviour, IWeeklyUpdate
{
    public CompanyController companyController;
    public GameObject companyButtonPrefab;
    public Transform buttonParent;
    public GameObject lineScrollView;
    public Transform lineContent;
    public GameObject lineButtonPrefab;
    public GameObject locomotiveScrollView;
    public Transform locomotiveContent;
    public GameObject locomotivePrefab;

    private List<CompanyData> companies;
    private CompanyData selectedCompany;
    private LineData selectedLine;
    private GameObject selectedCompanyButton;
    private GameObject selectedLineButton;

    void Start()
    {
        AddLayoutComponents(lineContent);
        AddLayoutComponents(locomotiveContent);

        companies = companyController.Companies;

        foreach (CompanyData company in companies)
        {
            GameObject button = Instantiate(companyButtonPrefab, buttonParent);
            button.GetComponentInChildren<Text>().text = company.Name;
            button.GetComponent<Button>().onClick.AddListener(() => OnCompanyButtonClicked(company, button));
        }
    }

    void AddLayoutComponents(Transform content)
    {
        if (content.gameObject.GetComponent<VerticalLayoutGroup>() == null)
        {
            VerticalLayoutGroup verticalLayoutGroup = content.gameObject.AddComponent<VerticalLayoutGroup>();
            verticalLayoutGroup.childAlignment = TextAnchor.UpperCenter;
            verticalLayoutGroup.spacing = 10; // Примерный отступ между элементами
            verticalLayoutGroup.padding = new RectOffset(10, 10, 10, 10); // Отступы от краев контейнера
            verticalLayoutGroup.childForceExpandWidth = true;
            verticalLayoutGroup.childForceExpandHeight = false;
        }

        if (content.gameObject.GetComponent<ContentSizeFitter>() == null)
        {
            ContentSizeFitter contentSizeFitter = content.gameObject.AddComponent<ContentSizeFitter>();
            contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
    }

    void OnCompanyButtonClicked(CompanyData company, GameObject companyButton)
    {
        //foreach(var line in company.Lines)
        //{
        //    Debug.Log("L "+line);
        //}
        if (selectedCompany == company)
        {
            selectedCompany = null;
            DeselectCompanyButton(companyButton);
            buttonParent.gameObject.SetActive(true);
            lineScrollView.SetActive(false);
            locomotiveScrollView.SetActive(false);
        }
        else
        {
            if (selectedCompanyButton != null)
            {
                DeselectCompanyButton(selectedCompanyButton);
            }

            selectedCompany = company;
            selectedCompanyButton = companyButton;
            SelectCompanyButton(companyButton);
            PopulateLines(company);
        }
    }

    void OnLineButtonClicked(LineData line, GameObject lineButton)
    {
        if (selectedLine == line)
        {
            selectedLine = null;
            DeselectLineButton(lineButton);
            locomotiveScrollView.SetActive(false);
        }
        else
        {
            if (selectedLineButton != null)
            {
                DeselectLineButton(selectedLineButton);
            }

            selectedLine = line;
            selectedLineButton = lineButton;
            SelectLineButton(lineButton);
            PopulateLocomotives(line);
        }
    }

    void SelectCompanyButton(GameObject button)
    {
        button.GetComponent<Image>().color = Color.gray;
    }

    void DeselectCompanyButton(GameObject button)
    {
        button.GetComponent<Image>().color = Color.white;
    }

    void SelectLineButton(GameObject button)
    {
        button.GetComponent<Image>().color = Color.gray;
    }

    void DeselectLineButton(GameObject button)
    {
        button.GetComponent<Image>().color = Color.white;
    }

    void PopulateLines(CompanyData company)
    {
        lineScrollView.SetActive(true);
        locomotiveScrollView.SetActive(false);

        foreach (Transform child in lineContent)
        {
            Destroy(child.gameObject);
        }

        foreach (LineData line in company.Lines)
        {
            GameObject button = Instantiate(lineButtonPrefab, lineContent);
            Text[] texts = button.GetComponentsInChildren<Text>();

            texts[0].text = line.Name;
            texts[1].text = "Киллометраж: " + line.kilometrag;
            texts[2].text = "Паровозов: " + line.Locomotives.Count;

            button.GetComponent<Button>().onClick.AddListener(() => OnLineButtonClicked(line, button));
        }
    }

    void PopulateLocomotives(LineData line)
    {
        locomotiveScrollView.SetActive(true);

        foreach (Transform child in locomotiveContent)
        {
            Destroy(child.gameObject);
        }

        foreach (CompanyLocomotiveData locomotive in line.Locomotives)
        {
            GameObject item = Instantiate(locomotivePrefab, locomotiveContent);
            Text[] texts = item.GetComponentsInChildren<Text>();
            texts[0].text = locomotive.Name;
            texts[1].text = "Осталось: " + locomotive.ostalos + " недель";
        }
    }

    public void WeekTick()
    {
        if (selectedCompany != null)
        {
            PopulateLines(selectedCompany);
        }

        if (selectedLine != null)
        {
            PopulateLocomotives(selectedLine);
        }
    }
}
