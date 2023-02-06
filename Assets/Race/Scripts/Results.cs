using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI resultsText;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectsOfType<GameObject>();
        resultsText.text = "RACE DONE";

        //GameObject winner = GameObject.FindGameObjectsWithTag
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
