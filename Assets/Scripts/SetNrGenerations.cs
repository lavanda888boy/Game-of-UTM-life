using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetNrGenerations : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SetNrOfGenerations()
    {
        Debug.Log(inputField.text);
    }
}
