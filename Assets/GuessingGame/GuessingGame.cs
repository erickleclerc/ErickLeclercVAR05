using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessingGame : MonoBehaviour
{
    public TextMeshProUGUI consoleTalking;
    public TMP_InputField userInput;
    

    public void MyFunction()
    {
        Debug.Log("Pick a number");

        consoleTalking.text = "Pick an Number";
    }


    public void GuessingTime()
    {
        consoleTalking.text = "Guess a number between 1 and ..." + userInput.text;

        userInput.text = "";


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

}
