using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Sprite[] cardPNG;
    int[] cardValues = new int[53];
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void GetCardValues()
    {

        //Assign the value to cards in deck
        int number = 0;
        for (int i = 0; i < cardPNG.Length; i++)
        {
            number = i; //2 of heart is worth 2, 3 of clubs is worth 3 
            number %= 13;

            if (number > 10 || number == 0)
            {
                number = 10; // 10 + FACE CARDS are worth 10
            }
            cardValues[i] = number++;
        }
    }

    public void Shuffle()
    {
        //shuffling the elements of the array aka cards in the deck
        for (int i = cardPNG.Length - 1; i > 0; i--) //-1 deals with the upside down card and excludes
        {
            int k = Mathf.FloorToInt(Random.Range(0, 1.0f) * cardPNG.Length - 1) + 1;
            Sprite appearance = cardPNG[k];
            cardPNG[i] = cardPNG[k];
            cardPNG[k] = appearance; //keeps the proper PNG to the proper number when rearranging

            int value = cardValues[i];
            cardValues[i] = cardValues[k];
            cardValues[k] = value;  //keeps the proper value to the proper card when rearranging (2 of aces is still worth 2 even if in deck it's 6)
        }
    }

    public int Dealing()
    {
        //cardDetails.SetSprite
        return 0;
    }
}
