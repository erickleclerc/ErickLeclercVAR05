using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlackJackGame : MonoBehaviour
{
    enum Suit { Hearts, Spades, Diamonds, Clubs }

    public TextMeshPro wordsOnCard;
    public int playerTotalScore;
    public int dealerTotalScore;
    public TextMeshProUGUI playerHandDisplay;
    public TextMeshProUGUI dealerHandDisplay;
    public TextMeshProUGUI finalResult;
    public GameObject resetButton;
    public GameObject dealCardsButton;
    public GameObject hitButton;
    public GameObject standButton;
    public GameObject cardPrefab;
    public GameObject hiderCard;

    private float cardPosition = .75f;

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
    } //Defining the Cards's value, suit, and name

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
    } // CREAING THE DECK

    private void Update()
    {
        if (playerTotalScore > 21)
        {
            finalResult.text = "BUSTED";
            resetButton.gameObject.SetActive(true);
            dealCardsButton.gameObject.SetActive(false);
            hitButton.gameObject.SetActive(false);
            standButton.gameObject.SetActive(false);
        }
        else if (playerTotalScore == 21)
        {
            finalResult.text = "BLACKJACK! You Win!";
            resetButton.gameObject.SetActive(true);
            dealCardsButton.gameObject.SetActive(false);
            hitButton.gameObject.SetActive(false);
            standButton.gameObject.SetActive(false);
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


        dealCardsButton.SetActive(false);
    } //Deals the first 2 cards for EACH PLAYER

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

            cardPosition = cardPosition + 1.25f;
        }

        //if score > 21, INSTANT BUST, RESET GAME
    }

    public void HitNextDealerCard()
    {
        dealerHandDisplay.text = $"Hand Value: {dealerTotalScore}";

        // add more cards to player
        while (dealerTotalScore < 17)
        {
            int selectedCardIndex = Random.Range(0, deck.Count);
            MyCard dealtCard = deck[selectedCardIndex];
            GameObject nextCardForPlayer = Instantiate(cardPrefab, new Vector3(cardPosition, 0.3f, 3f), Quaternion.identity);
            nextCardForPlayer.GetComponentInChildren<TextMeshPro>().text = dealtCard.ToString();

            dealerTotalScore = dealerTotalScore + dealtCard.value;
            dealerHandDisplay.text = $"Hand Value: {dealerTotalScore}";

            cardPosition = cardPosition + 1.25f;
        }
    }

    public void StandButton()
    {
        hiderCard.SetActive(false);
        dealerHandDisplay.text = $"Hand Value: {dealerTotalScore}";

        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);

        while (dealerTotalScore < 17)
        {
            HitNextDealerCard();
        }

        CompareScores();

        //else if add more cards to dealer until > player score or over 21
    }

    void CompareScores()
    {
        if (dealerTotalScore > playerTotalScore && dealerTotalScore <= 21)
        {
            finalResult.text = "Dealer Wins";
        }
        else if (dealerTotalScore < playerTotalScore)
        {
            finalResult.text = "You Win!";
        }
        else if (dealerTotalScore == playerTotalScore)
        {
            finalResult.text = "Push. Keep Your Bet";
        }
        else if (dealerTotalScore > 21)
        {
            finalResult.text = "Dealer Busted. You Win!";
        }



        resetButton.gameObject.SetActive(true);
    }
}
