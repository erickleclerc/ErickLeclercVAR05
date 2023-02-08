using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class RaceManager : MonoBehaviour
{
    private int turnNumber;

    public GameObject resultsObject;
    public TextMeshProUGUI turnTracker;
    public float turnRoundSpeed = .5f;
    public bool finishLine = false;

    public IEnumerator GameTurns()
    {
        while (finishLine == false)
        {
            //other racers' turns
            GameObject[] otherPlayer = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < otherPlayer.Length; i++)
            {
                otherPlayer[i].GetComponent<MoveAhead>().MoveForward();
            }

            //player's turn
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
        if (finishLine == true)
        {
            StopAllCoroutines();
            resultsObject.SetActive(true);
        }
    }

    private void SelectPlayer()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    hit.collider.transform.tag = "Selected Player";

                    turnTracker.text = $"Turn Number: {turnNumber}";
                    StartCoroutine(GameTurns());
                }
            }
        }
    }
}
