using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class RaceManager : MonoBehaviour
{
    private int turnNumber;
    public bool finishLine = false;

    public TextMeshProUGUI turnTracker;
    public float turnRoundSpeed = .5f;

    public IEnumerator GameTurns()
    {
        while (finishLine == false)
        {
            //ai will play turn
            GameObject otherPlayer = GameObject.FindWithTag("Player");
            otherPlayer.GetComponent<MoveAhead>().MoveForward();

            //player will have a turn
            GameObject myPlayer = GameObject.FindWithTag("Selected Player");
            myPlayer.GetComponent<MoveAhead>().MoveForward();

            //next turn
            turnNumber++;
            turnTracker.text = $"Turn Number: {turnNumber}";

            yield return new WaitForSeconds(turnRoundSpeed);
        }
    }

    void Start()
    {
        turnNumber = 0;
        turnTracker.text = "Select Your Player";
    }

    void Update()
    {
        SelectPlayer();
        //Debug.Log(finishLine);
        if (finishLine == true)
        {
            StopCoroutine(GameTurns());
        }
    }

    private void SelectPlayer()
    {
        //selecting player on screen
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    hit.collider.transform.tag = "Selected Player";
                    Debug.Log("Player selected and tagged");

                    turnTracker.text = $"Turn Number: {turnNumber}";
                    StartCoroutine(GameTurns());

                }
            }
        }
    }
}
