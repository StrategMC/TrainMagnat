using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Autorization : MonoBehaviour
{
    public DbController dbController;
    public Button autoButton;
    public InputField nameInput;
    public InputField passwordInput;
    public Text OutText;

    void Start()
    {
        autoButton.onClick.AddListener(Auto);
    }

    // Update is called once per frame
    void Auto()
    {
        if(string.IsNullOrEmpty(nameInput.text)||string.IsNullOrEmpty(passwordInput.text))
        {
            OutText.text = "������ ���� �����!";
            return;
        }
        if (dbController.ExaminationUser(nameInput.text))
        {
            OutText.text = "������ ������������ ���!";
            return;
        }
        if(!dbController.PasswordChek(nameInput.text,passwordInput.text))
        {
            OutText.text = "������ �� ������!";
            return;
        }
        OutText.text = "����";
        PlayerPrefs.SetInt("id player", dbController.SetPlayerId(nameInput.text));
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
