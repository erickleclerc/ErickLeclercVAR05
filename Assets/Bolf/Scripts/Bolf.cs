using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Bolf : MonoBehaviour
{
    public float shotForce = 45f;
    public TextMeshProUGUI resultsText;
    public TextMeshProUGUI scoreText;
    public GameObject arrow;
    public Button restartLevel;
    public Button returnToMenu;
    public Vector3 startingPoint;
    public int score = 0;

    private int attempt = 1;
    private float timer = 8f;
    private bool countingDown = false;
    private bool spinBackAndForth = true;
    private Rigidbody rb;

    private void Start()
    {
        gameObject.transform.position = startingPoint;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (spinBackAndForth)
        {
            transform.eulerAngles = new Vector3(0, Mathf.PingPong(Time.time * 60, 90) - 45, 90);
        }
        //Vector3 origin = gameObject.transform.position;
        //Vector3 endPoint = transform.TransformPoint(Vector3.forward * 3);
        //Debug.DrawLine(origin, endPoint, Color.green, .2f);


        if (Keyboard.current.spaceKey.wasPressedThisFrame && !countingDown)
        {
            arrow.SetActive(false);
            spinBackAndForth=false;
            rb.isKinematic = false;
            Vector3 forceDirection = transform.TransformDirection(Vector3.forward) * shotForce;

            rb.AddForce(forceDirection, ForceMode.Impulse);
            countingDown = true;
        }

        if (countingDown && timer > 0)  //COUNTDOWN AFTER SHOT IS MADE
        {
            timer -= Time.deltaTime;
        }
        else if (countingDown && timer <= 0)
        {
            countingDown = false;
            Debug.Log("DONE ROUND");
            CheckResults();


            //SETUP ATTTEMPT 2
            attempt++;
        }

        scoreText.text = "Score: " + score.ToString();
 
       
        if (attempt == 3)
        {
            restartLevel.gameObject.SetActive(true);
            returnToMenu.gameObject.SetActive(true);

            gameObject.SetActive(false);
        }                                                        //Restart Game/Return to Menu
    }

    private void CheckResults()
    {
        if (score == 0)
        {
            resultsText.gameObject.SetActive(true);
            resultsText.text = "GUTTER";
            StartCoroutine(BeginNextAttempt());
        }
        else if (attempt == 1 && score == 10)
        {
            resultsText.gameObject.SetActive(true);
            resultsText.text = "STRIKE";
            StartCoroutine(BeginNextAttempt());
        }
        else if (attempt == 2 && score == 10)
        {
            resultsText.gameObject.SetActive(true);
            resultsText.text = "SPARE";
            StartCoroutine(BeginNextAttempt());
        }
        else
        {
            StartCoroutine(BeginNextAttempt());
        }
    }

    IEnumerator BeginNextAttempt()
    {
        yield return new WaitForSeconds(2);

        
        timer = 8f;
        countingDown = false;
        resultsText.gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
        gameObject.transform.position = startingPoint;
        spinBackAndForth = true;
        rb.isKinematic = true;
        arrow.SetActive(true);
        StopCoroutine(BeginNextAttempt());
    }
}
