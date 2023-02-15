using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Deck deckScript;
    public CardDetails cardDetailsScript;
    public TextMeshProUGUI playerHandValue;

    //total score of the player/dealer's hand
    public int handValue = 0;

    public GameObject[] hand;

    public int cardIndex = 0;
    
    //Tracking aces for 1 or 11 score
    List<CardDetails> acesList = new List<CardDetails>();

    public void StartPlaying()
    {
        GetCard(); // get 1st card
        GetCard(); // get 2nd card
    }

    public int GetCard()
    {
        //receive a car, use a dealt card to assign the PNG and value to the card at player's spot
        int cardValue = deckScript.Dealing(hand[cardIndex].GetComponent<CardDetails>());

        //show the card on screen
        hand[cardIndex].GetComponent<Renderer>().enabled = true;

        //Add the card's value to the total score
        handValue += cardValue;

        if (cardValue == 1) //if it's an ace
        {
            cardValue = 11;
        }    
        playerHandValue.text = $"Hand Value: {handValue.ToString()}";
        cardIndex++;
        return handValue;
    }
}
