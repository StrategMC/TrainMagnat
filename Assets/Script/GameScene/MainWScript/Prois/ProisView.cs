using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProisView : MonoBehaviour
{
    public ProisData ProisData;
    public ProisController ProisController;
    public Text pointText;
    public Text proisText;
    public Button PlusButton;
    public Button MinusButton;
    private void Start()
    {
        PlusButton.onClick.AddListener(ProisController.AddPoint);
        MinusButton.onClick.AddListener(ProisController.MinusPoint);
    }
    
    public void ViewPoint()
    {
        pointText.text = $"{ProisData.proispoint}";
    }
    public void ViewProis()
    {
        proisText.text = $"{ProisData.proisinweek} ед.";
    }
}
