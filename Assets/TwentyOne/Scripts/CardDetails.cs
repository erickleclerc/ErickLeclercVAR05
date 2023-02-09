using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDetails : MonoBehaviour
{
    public Renderer circle, topBar;
    public Material red, black;
    public enum CardColor { red, black}

    public void SetColor (CardColor color)
    {
        Material mat = color == CardColor.black ? black : red;


    }


    
}
