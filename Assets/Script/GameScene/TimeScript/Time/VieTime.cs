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
            TimeText.text = $"����: {Time.week}� {Time.month}� {Time.year}�";
        }
    }
}