using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using CodeMonkey;
using TMPro;

public class UI_InputWindow : MonoBehaviour
{
    private static UI_InputWindow instance;

    private Button_UI okBtn;
    private Button_UI cancelBtn;
    private TMP_InputField inputField;

    private void Awake()
    {
        instance = this;

        okBtn = transform.Find("okBtn").GetComponent<Button_UI>();
        cancelBtn = transform.Find("cancelBtn").GetComponent<Button_UI>();
        inputField = transform.Find("inputField").GetComponent<TMP_InputField>();
    }

    private void Start()
    {
        transform.Find("submitScoreBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            UI_Blocker.Show_Static();
            Show_Static("Test Title", "", "123456789", 3, () =>
            {
                //click cancel
                UI_Blocker.Hide_Static();
            }, (string inputText) =>
            {
                //Clicked Ok
                CMDebug.TextPopupMouse("Ok:" + inputText);
            });
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            okBtn.ClickFunc();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cancelBtn.ClickFunc();
        }
    }

    private void Show(string titleString, string inputString, string validCharacters, int characterLimit, Action onCancel, Action<string> onOk)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();

        inputField.onValidateInput = (string text, int charIndex, char addedchar) =>
        {
            return ValidateChar(validCharacters, addedchar);
        };

        inputField.characterLimit = characterLimit;
        inputField.text = inputString;

        okBtn.ClickFunc = () =>
        {
            Hide();
            onOk(inputField.text);
        };

        cancelBtn.ClickFunc = () => {
            Hide();
            onCancel();
        };
    }

    

    private char ValidateChar(string validCharacters, char addedChar)
    {
        if (validCharacters.IndexOf(addedChar) != -1)
        {
            //valid
            return addedChar;
        } else
        {
            //invalid
            return '\0';
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void Show_Static(string titleString, string inputString, string validCharacters, int characterLimit, Action onCancel, Action<string> onOk)
    {
        instance.Show(titleString, inputString, validCharacters, characterLimit, onCancel, onOk);
    }
}
