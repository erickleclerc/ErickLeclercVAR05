using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TMP_Text countdownText;
    public GameObject stageThree;

    public float timer = 4f;


    void Start()
    {
        countdownText.color = Color.red;
    }

    void Update()
    {
       timer -= Time.deltaTime;


        if (timer > 3)
        {
            countdownText.text = "4";
        }
        else if (timer > 2 && timer < 3)
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
