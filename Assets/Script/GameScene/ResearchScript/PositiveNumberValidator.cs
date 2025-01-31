using UnityEngine;
using UnityEngine.UI;

public class PositiveNumberValidator : MonoBehaviour
{
    public InputField inputField;
    public Text textOut;
    public ResearchController controller;
    void Start()
    {
        if (inputField != null)
        {
            inputField.text = "1";
            inputField.onValueChanged.AddListener(ValidateInput);
            inputField.onEndEdit.AddListener(ValidateOnEndEdit);
        }
    }

    void ValidateInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        string validatedInput = "";
        foreach (char c in input)
        {
            if (char.IsDigit(c) || c == '.')
            {
                validatedInput += c;
            }
        }
        if (float.TryParse(validatedInput, out float result) && result >= 0)
        {
            inputField.text = validatedInput;
            textOut.text = validatedInput;
            controller.PointUpdate(validatedInput);
        }
        else
        {
            inputField.text = "";
        }
    }

    void ValidateOnEndEdit(string input)
    {
        if (string.IsNullOrEmpty(input) || !float.TryParse(input, out float result) || result < 0)
        {
            inputField.text = "1"; 
        }
        controller.PointUpdate(input);
    }
}
