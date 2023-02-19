using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlackJackGame : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject hiderCard;

    enum Suit { Hearts, Spades, Diamonds, Clubs }

    public TextMeshPro wordsOnCard;

    public int playerTotalScore;
    public int dealerTotalScore;

    public TextMeshProUGUI playerHandDisplay;
    public TextMeshProUGUI dealerHandDisplay;
    public TextMeshProUGUI finalResult;
    public GameObject resetButton;

    private float cardPosition = .5f;

    private class MyCard : object
    {
        public string name;

        /// <summary>
        /// The score this card is worth in blackjack.
        /// </summary>
        public int value;

        public Suit suit;

        public MyCard(string name, int value, Suit suit)
        {
            this.name = name;
            this.value = value;
            this.suit = suit;
        }

        public override string ToString()
        {
            return $"{name} of {suit}";
        }
    }

    List<MyCard> deck = new List<MyCard>();

    private void Start()
    {
        //Creating the DECK
        List<string> names = new List<string>()
        {
            "Ace",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten",
            "Jack",
            "Queen",
            "King"
        };
        for (int s = 0; s < 4; s++)
        {
            for (int v = 0; v < 13; v++)
            {
                Suit suit = (Suit)s;

                int score;

                if (v < 10 && v > 0)
                {
                    score = v + 1;              // 2 - 9 cards worth 2 - 9
                }
                else if (v == 0)
                {
                    score = 11;                 //aces worth 11
                }
                else
                {
                    score = 10;                 // 10, J, Q, K worth 10
                }

                MyCard card = new MyCard(names[v], score, suit);

                deck.Add(card);
            }
        }
    }

    private void Update()
    {
        if (playerTotalScore > 21)
        {
            finalResult.text = "BUSTED";
            resetButton.gameObject.SetActive(true);
            
            }
        else if (playerTotalScore == 21)
        {
            finalResult.text = "BLACKJACK! You Win!";
            resetButton.gameObject.SetActive(true);
        }
    }

    public void DealCards()
    {
        //instantiate 2 cards for player 

        int selectedCardIndex = Random.Range(0, deck.Count);
        MyCard dealtCard = deck[selectedCardIndex];
        deck.RemoveAt(selectedCardIndex);
        GameObject firstCard = Instantiate(cardPrefab, new Vector3(-2.5f, 0.3f, 0.28f), Quaternion.identity);
        firstCard.GetComponentInChildren<TextMeshPro>().text = dealtCard.ToString();

        int selectedCardIndex2 = Random.Range(0, deck.Count);
        MyCard dealtCard2 = deck[selectedCardIndex2];
        deck.RemoveAt(selectedCardIndex);
        GameObject secondCard = Instantiate(cardPrefab, new Vector3(-0.5f, 0.3f, 0.28f), Quaternion.identity);
        secondCard.GetComponentInChildren<TextMeshPro>().text = dealtCard2.ToString();

        playerTotalScore = dealtCard.value + dealtCard2.value;
        playerHandDisplay.text = $"Hand Value: {playerTotalScore}";



        //instantiate 2 cards for dealer 

        int selectedCardIndex3 = Random.Range(0, deck.Count);
        MyCard dealtCard3 = deck[selectedCardIndex3];
        GameObject firstCardDealer = Instantiate(cardPrefab, new Vector3(-2.5f, 0.3f, 3f), Quaternion.identity);
        firstCardDealer.GetComponentInChildren<TextMeshPro>().text = dealtCard3.ToString();
        hiderCard.gameObject.SetActive(true);

        int selectedCardIndex4 = Random.Range(0, deck.Count);
        MyCard dealtCard4 = deck[selectedCardIndex4];
        GameObject secondCardDealer = Instantiate(cardPrefab, new Vector3(-0.5f, 0.3f, 3f), Quaternion.identity);
        secondCardDealer.GetComponentInChildren<TextMeshPro>().text = dealtCard4.ToString();

        dealerTotalScore = dealtCard3.value + dealtCard4.value;
        dealerHandDisplay.text = $"Hand Value: {dealerTotalScore - dealtCard3.value}";


        //IF 21 INSTANT WIN

    }

    public void HitNextCard()
    {
        // add more cards to player
        if (playerTotalScore < 21)
        {
            int selectedCardIndex = Random.Range(0, deck.Count);
            MyCard dealtCard = deck[selectedCardIndex];
            GameObject nextCardForPlayer = Instantiate(cardPrefab, new Vector3(cardPosition, 0.3f, .28f), Quaternion.identity);
            nextCardForPlayer.GetComponentInChildren<TextMeshPro>().text = dealtCard.ToString();

            playerTotalScore = playerTotalScore + dealtCard.value;
            playerHandDisplay.text = $"Hand Value: {playerTotalScore}";

            cardPosition = cardPosition + 1f;
        }

        //if score > 21, INSTANT BUST, RESET GAME
    }

    public void HitNextDealerCard()
    {
        // add more cards to player
        while (dealerTotalScore < 21)
        {
            int selectedCardIndex = Random.Range(0, deck.Count);
            MyCard dealtCard = deck[selectedCardIndex];
            GameObject nextCardForPlayer = Instantiate(cardPrefab, new Vector3(cardPosition, 0.3f, 3f), Quaternion.identity);
            nextCardForPlayer.GetComponentInChildren<TextMeshPro>().text = dealtCard.ToString();

            dealerTotalScore = dealerTotalScore + dealtCard.value;
            dealerHandDisplay.text = $"Hand Value: {dealerTotalScore}";

            cardPosition = cardPosition + 1f;
        }
    }

    public void StandButton()
    {
        hiderCard.SetActive(false);
        dealerHandDisplay.text = $"Hand Value: {dealerTotalScore}";

        if (dealerTotalScore >= 16)
        {
            CompareScores();
        }
        else
        {

        }


        //if 16 stop and compare,

        //else if add more cards to dealer until > player score or over 21
    }

    void CompareScores()
    {

    }
}
