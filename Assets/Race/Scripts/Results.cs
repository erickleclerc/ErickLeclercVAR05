using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI resultsText;
    public TextMeshProUGUI runnerUpsText;

    private Vector3 finishLine = new(0, 0, 10);

    void Start()
    {
        GameObject winner = GameObject.FindGameObjectWithTag("Winner");

        GameObject[] losers = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] losers2 = GameObject.FindGameObjectsWithTag("Selected Player");
        GameObject[] concatArray = losers.Concat(losers2).ToArray();


        Array.Sort(concatArray, (g1, g2) =>
    (Vector3.Distance(finishLine, g1.transform.position) >
     Vector3.Distance(finishLine, g2.transform.position)) ? 1 : -1);


        for (int i = 0; i < concatArray.Length; i++)
        {
            Debug.Log(concatArray[i].name + Vector3.Distance(concatArray[i].transform.position, finishLine));
        }


        resultsText.text = "WINNER: " + winner.name;

        runnerUpsText.text = "Runner-Up Order:" + "\n";
        foreach (GameObject loser in concatArray)
        {
            runnerUpsText.text += loser.name + "\n" ;
        }
    }


    

   


}
