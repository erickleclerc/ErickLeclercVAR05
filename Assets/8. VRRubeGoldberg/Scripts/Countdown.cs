using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMP_Text countdownText;
    public GameObject stageThree;

    public float timer = 3f;


    // Start is called before the first frame update
    void Start()
    {
        countdownText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
       timer -= Time.deltaTime;


        if (timer > 2)
        {
            countdownText.text = "3";
        }
        else if (timer > 1 && timer < 2)
        {
            countdownText.text = "2";
        }
        else if (timer > 0 && timer < 1)
        {
            countdownText.text = "1";
        }
        else if (timer < 0 && timer > -1)
        {
            countdownText.text = "GO!";
            countdownText.color = Color.green;
        }
        else if (timer < -1)
        {
            stageThree.gameObject.SetActive(true);
            Destroy(gameObject);    
        }


    }
}
