using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GlabalGame
{

    public class VieTime : MonoBehaviour
    {
        public Text TimeText;
        public void View(TimeData Time)
        {
            TimeText.text = $"Дата: {Time.week}н {Time.month}м {Time.year}г";
        }
    }
}