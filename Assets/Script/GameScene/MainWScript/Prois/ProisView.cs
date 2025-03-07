using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProisView : MonoBehaviour
{
    public ProisController ProisController;
    public Text pointText;
    public Text proisText;
    public Button PlusButton;
    public Button MinusButton;
    private void Start()
    {
        PlusButton.onClick.AddListener(ProisController.AddPoint);
        MinusButton.onClick.AddListener(ProisController.MinusPoint);
        ViewPoint();
        ViewProis();
    }
    
    public void ViewPoint()
    {
        pointText.text = $"{ProisController.ProisData.proispoint}";
    }
    public void ViewProis()
    {
        proisText.text = $"{ProisController.ProisData.proisinweek} ед.";
    }
}
