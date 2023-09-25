using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextOnEnter : MonoBehaviour
{
    public InputField inputField; 
    public Text targetText;        

    private void Start()
    {
        inputField.onEndEdit.AddListener(OnInputFieldSubmit);
    }

    private void OnInputFieldSubmit(string submittedText)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            targetText.text = submittedText;
            inputField.text = ""; 
        }
    }
}