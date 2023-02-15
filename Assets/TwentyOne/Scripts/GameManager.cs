using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button dealCardsButton;
    public Button hitButton;
    public Button standButton;

   public Player player;
   public Player dealer;

    // Start is called before the first frame update
    void Start()
    {
        dealCardsButton.onClick.AddListener(() => DealHasBeenClicked());
        hitButton.onClick.AddListener(() => HitHasBeenClicked());
        standButton.onClick.AddListener(() => StandHasBeenClicked());

    }
    private void DealHasBeenClicked()
    {
        GameObject.Find("Deck").GetComponent<Deck>().Shuffle();         //shuffle before dealing cards
        player.StartPlaying();
        dealer.StartPlaying();
    }
    private void HitHasBeenClicked()
    {
        throw new NotImplementedException();
    }
    private void StandHasBeenClicked()
    {
        throw new NotImplementedException();
    }

   

    

}
