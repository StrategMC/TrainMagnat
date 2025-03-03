using UnityEngine;
using UnityEngine.UI;

namespace GlabalGame
{
    public class ProgressBarController : MonoBehaviour
    {
        public Image ProgressBar;

        void Start()
        {
            ProgressBar.fillAmount = 0;
        }

        public void View(TimeData Time)
        {
            ProgressBar.fillAmount=Time.dayProgress/7;
            
        }
    }

}

