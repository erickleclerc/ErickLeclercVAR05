using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAhead : MonoBehaviour
{
    private float critChance;
    private int terrainNumber; //1 is regular, 2 is muddy, 3 is finish

    private RaceManager raceManagerScript;

    private void Start()
    {
        raceManagerScript = GetComponent<RaceManager>();
    }

    private void Update()
    {
        Debug.Log(terrainNumber);
    }

    public void MoveForward()
    {
        critChance = Random.Range(0f, 1f);
        Debug.Log(critChance);
        if (critChance < 0.25f && terrainNumber == 1)
        {
            gameObject.transform.position = transform.position + new Vector3(0, 0, 10);
        }
        else if (critChance < 0.125f && terrainNumber == 2)
        {
            gameObject.transform.position = transform.position + new Vector3(0, 0, 10);
        }
        else
        {
            gameObject.transform.position = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Muddy")
        {
            terrainNumber = 2;
        }
        else if (other.gameObject.tag == "Regular")
        {
            terrainNumber = 1;
        }
        else if (other.gameObject.tag == "FinishLine")
        {
            //StopCoroutine(raceManagerScript.GameTurns());
            raceManagerScript.finishLine = true;

            terrainNumber = 3;
            Application.Quit();
            //END THE COROUTINE OF THE OTHER PLAYER TOO

        }
    }
}
