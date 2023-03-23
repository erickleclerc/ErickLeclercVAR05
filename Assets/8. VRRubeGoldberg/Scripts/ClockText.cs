using UnityEngine;
using TMPro;
using System;

public class ClockText : MonoBehaviour
{
    public TMP_Text clockText;

    void Update()
    {
        clockText.text = DateTime.Now.ToString();
    }
}
