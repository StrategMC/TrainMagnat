using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public Button ButtonAutoriacion;
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("id player"));
        ButtonAutoriacion.onClick.AddListener(AutorizacionButtonCklick);
    }

    void AutorizacionButtonCklick()
    {
        SceneManager.LoadScene("RA");
    }
}
