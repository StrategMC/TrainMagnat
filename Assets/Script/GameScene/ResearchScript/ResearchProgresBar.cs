using GlabalGame;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResearchProgresBar : MonoBehaviour
{
    public Image ProgressBar;
    public ReasearchData data;
    public Text TextProcent;


    void Start()
    {
        ProgressBar.fillAmount = 0;
    }

    public void Move()
    {
        if (data != null && data.technologys != null && data.technologys.Count > 0)
        {
            if (data.technologys[0].need != 0)
            {
                ProgressBar.fillAmount = (float)data.technologys[0].need / (float)data.technologys[0].cost;
                TextProcent.text = (((float)data.technologys[0].need / (float)data.technologys[0].cost) * 100).ToString("F1") + "%";
            }
            else
            {
                ProgressBar.fillAmount = 0f;
                TextProcent.text = "0%";
            }
        }
        //else
        //{
        //    Debug.LogError("Индекс выходит за пределы допустимого диапазона или данные не инициализированы.");
        //}
    }

}
