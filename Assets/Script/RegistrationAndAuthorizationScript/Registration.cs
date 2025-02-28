using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public DbController dbController;
    public Button regButton;
    public InputField nameInput;    
    public InputField passwordInput;
    public InputField password2Input;
    public Text OutText;

    void Start()
    { 
        regButton.onClick.AddListener(OnRegistrationClicked);
    }

    void OnRegistrationClicked()
    {
        if (string.IsNullOrEmpty(nameInput.text) || string.IsNullOrEmpty(passwordInput.text) || string.IsNullOrEmpty(password2Input.text))
        {
            OutText.text = "������ ���� �����!";
            return;
        }
        if(password2Input.text!=passwordInput.text)
        {
            OutText.text = "������ �� ���������";
            return;
        }
        if (!dbController.ExaminationUser(nameInput.text))
        {
            OutText.text = "����� ������������ ��� ����!";
            return;
        }
        dbController.AddUser(nameInput.text, passwordInput.text);
        OutText.text = "������������ ��������";
    }
}