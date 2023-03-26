using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetNrGenerations : MonoBehaviour
{
    public TMP_InputField InputField;
    public static int nrOfGenerations;

    public void SetNrOfGenerations()
    {
        nrOfGenerations = int.Parse(InputField.text);
        InputField.image.color = new Color(0.22f, 0.79f, 0.43f, 0.7f);
    }
}
