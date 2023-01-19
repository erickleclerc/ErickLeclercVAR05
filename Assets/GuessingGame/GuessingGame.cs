using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessingGame : MonoBehaviour
{
    public TextMeshProUGUI consoleTalking;
    public TMP_InputField inputUpperBounds;
    public TMP_InputField inputGuessingNumber;

    int randomNumber;
    int upperBounds;
    int inputGuessingNumberAgain;

    public void MyFunction()
    {
        Debug.Log("Pick a number");

        consoleTalking.text = "Pick an Number";
    }

    public void SettingBounds()
    {
        consoleTalking.text = "Guess a number between 1 and " + inputUpperBounds.text;

        upperBounds = int.Parse(inputUpperBounds.text);

        randomNumber = Random.Range(1, upperBounds);

        Debug.Log(randomNumber);
    }

    public void GuessingTime()
    {
        inputGuessingNumberAgain = int.Parse(inputGuessingNumber.text);

        if (inputGuessingNumberAgain > randomNumber)
        {
            consoleTalking.text = "Too high! Guess Again!";
        }
        else if (inputGuessingNumberAgain < randomNumber)
        {
            consoleTalking.text = "Too low! Guess Again!";
        }
        else if (inputGuessingNumberAgain == randomNumber)
        {
            consoleTalking.text = "Congrats!";
        }
    }
}
