using UnityEngine;
using System.Collections;


public class PinBehaviour : MonoBehaviour
{
    public Bolf bolfScript;
    private bool hitAlready = false;

    public bool isKnockedOver = false;
    public float knockOverThreshold = 45f;


    // Update is called once per frame
    void Update()
    {
        if (hitAlready == false && transform.eulerAngles.z < 82 || hitAlready == false && transform.eulerAngles.z > 98) 
        {
            Debug.Log("HIT");
            bolfScript.score++;
            hitAlready = true;
            StartCoroutine(RemovePin());
        }
    }

    IEnumerator RemovePin()
    {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);
        StopCoroutine(RemovePin());
    }
}
