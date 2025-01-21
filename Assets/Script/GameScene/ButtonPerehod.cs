using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPerehod : MonoBehaviour
{
    public Button[] buttons = new Button[5];
    public GameObject[] panels = new GameObject[5];
    private GameObject activePanel;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OpenPanel(index));
        }
    }

    void OpenPanel(int index)
    {
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }

        panels[index].SetActive(true);
        activePanel = panels[index];
    }
}
