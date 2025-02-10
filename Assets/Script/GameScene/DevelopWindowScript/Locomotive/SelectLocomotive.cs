using GlobalGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLocomotive : MonoBehaviour
{
    public TimeController time;
    public GameObject Window;
    public SelectLocomotiveController controller;
    public SelectLocomotiveData data;
    public LocomotiveController locomotiveController;
    public GameObject locoPanel;

    public Text NameText;
    public Text SpeedText;
    public Text PowerText;
    public Text CostText;

    public bool eng;
    public bool cha;

    public Button ApcentButton;
    public Button OpenButton;
    public Button ExitButton;
    private void Start()
    {
        eng = false;
        cha=false;
        ExitButton.onClick.AddListener(Exit);
        OpenButton.onClick.AddListener(Open);
        ApcentButton.onClick.AddListener(Acept);
    }
    private void Acept()
    {
        if (NameText.text.Length>2 && eng == true && cha == true)
        {
            locomotiveController.AddLocomotiev(NameText.text,data.Speed,data.Power,data.Cost);
            Window.SetActive(false);
        }
    }
    private void Open()
    {
        time.Pause();
        Window.SetActive(true);
    }
    private void Exit()
    {
        Window.SetActive(false);
    }
    public void View()
    {
        if (eng == true && cha == true)
        {
            controller.Podschet();
            locoPanel.SetActive(true);
            SpeedText.text = $"Скорость: {data.Speed}";
            PowerText.text = $"Мощность: {data.Power}";
            CostText.text = $"Стоимость: {data.Cost}";
        }
    }
}
