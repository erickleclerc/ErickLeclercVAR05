using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Bolf : MonoBehaviour
{
    public float shotForce = 45f;
    public TextMeshProUGUI resultsText;
    public TextMeshProUGUI scoreText;
    public GameObject arrow;
    public PinBehaviour pinCheck;

    public int score;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, Mathf.PingPong(Time.time * 60, 90) - 45, 0);
        if (arrow.activeSelf)
        {
            arrow.gameObject.transform.eulerAngles = new Vector3(0, Mathf.PingPong(Time.time * 60, 90) - 45, 0);
        }





        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            arrow.SetActive(false);
            Vector3 forceDirection = transform.TransformDirection(Vector3.forward) * shotForce;

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.AddForce(forceDirection, ForceMode.Impulse);
        }


        Vector3 origin = gameObject.transform.position;
        Vector3 endPoint = transform.TransformPoint(Vector3.forward * 3);
        Debug.DrawLine(origin, endPoint, Color.green, .2f);


        scoreText.text = score.ToString();




        if (gameObject.transform.position.y < -2)
        {
            pinCheck.HasBeenHit();
        }



            if (gameObject.transform.position.y < -2 && score == 0)
        {
            resultsText.text = "GUTTER";
        }
        else if (gameObject.transform.position.y <-2 && score == 10)
        {
            resultsText.text = "STRIKE";
        }
    }

}
