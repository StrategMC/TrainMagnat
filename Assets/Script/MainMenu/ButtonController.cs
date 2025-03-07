using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public Button ButtonAutoriacion;
    public Button ButtonNewPlay;
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("id player"));
        ButtonAutoriacion.onClick.AddListener(AutorizacionButtonCklick);
        ButtonNewPlay.onClick.AddListener(NewPlay);
    }

    void AutorizacionButtonCklick()
    {
        SceneManager.LoadScene("RA");
    }
    void NewPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
