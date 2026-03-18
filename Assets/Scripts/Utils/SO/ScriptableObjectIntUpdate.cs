using System;
using TMPro;
using UnityEngine;

public class ScriptableObjectIntUpdate : MonoBehaviour
{
   public ScriptableObjectInt soInt;
   public TextMeshProUGUI uiTextValue;


    void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }

    void Update()
    {
        uiTextValue.text = "X " + soInt.value.ToString();
    }
}
