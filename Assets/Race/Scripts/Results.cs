using UnityEngine;
using TMPro;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI resultsText;
    public TextMeshProUGUI runnerUpsText;
    public Button restartSceneButton;
   
    void Start()
    {
        GameObject winner = GameObject.FindGameObjectWithTag("Winner");

        GameObject[] losers = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] losers2 = GameObject.FindGameObjectsWithTag("Selected Player");
        GameObject[] concatArray = losers.Concat(losers2).ToArray();

        GameObject finishLineLocation = GameObject.FindGameObjectWithTag("FinishLine");
        Vector3 finishLineSpot = finishLineLocation.transform.position;

        Array.Sort(concatArray, (g1, g2) =>
    (Vector3.Distance(finishLineSpot, g1.transform.position) >
     Vector3.Distance(finishLineSpot, g2.transform.position)) ? 1 : -1);

        for (int i = 0; i < concatArray.Length; i++)
        {
            Debug.Log(concatArray[i].name + Vector3.Distance(concatArray[i].transform.position, finishLineSpot));
        }

        resultsText.text = "WINNER: " + winner.name;
        runnerUpsText.text = "Runner-Up Order:" + "\n";
        foreach (GameObject loser in concatArray)
        {
            runnerUpsText.text += loser.name + "\n" ;
        }

        restartSceneButton.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
