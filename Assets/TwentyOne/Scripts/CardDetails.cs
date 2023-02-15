using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDetails : MonoBehaviour
{
    // Value of card, 7 of diamonds = 7, etc
    public int value = 0;

    public int GetValueOfCurrentCard()
    {
        return value;
    }

    public void SetValueOfCurrentCard(int newValue)
    {
        value = newValue;
    }

    public string GetPNGName()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }
    
}
