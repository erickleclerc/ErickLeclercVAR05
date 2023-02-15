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


    // Start is called before the first frame update
    void Start()
    {
        dealCardsButton.onClick.AddListener(() => DealHasBeenClicked());
        hitButton.onClick.AddListener(() => HitHasBeenClicked());
        standButton.onClick.AddListener(() => StandHasBeenClicked());

    }
    private void DealHasBeenClicked()
    {
        throw new NotImplementedException();
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
