using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverController : MonoBehaviour
{
    public GameObject Panel;
    public void Over()
    {
        Panel.SetActive(true);
    }
}
