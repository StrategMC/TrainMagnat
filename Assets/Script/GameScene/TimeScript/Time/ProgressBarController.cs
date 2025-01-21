using UnityEngine;
using UnityEngine.UI;

namespace GlabalGame
{
    public class ProgressBarController : MonoBehaviour
    {
        public Image ProgressBar;
        public TimeData Time;

        void Start()
        {
            ProgressBar.fillAmount = 0;
        }

        void Update()
        {
            ProgressBar.fillAmount=Time.dayProgress/7;
            
        }
    }

}

