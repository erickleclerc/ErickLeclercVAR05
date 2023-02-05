using UnityEngine;

public class MoveAhead : MonoBehaviour
{
    private float critChance;
    private int terrainNumber; //1 is regular, 2 is muddy, 3 is finish

    public RaceManager raceManagerScript;
    [SerializeField] GameObject raceManager;

    private void Awake()
    {
        //raceManagerScript = GetComponent<RaceManager>();
        raceManagerScript = raceManager.GetComponent<RaceManager>();
    }


    public void MoveForward()
    {
        critChance = Random.Range(0f, 1f);
        //Debug.Log(critChance);
        if (critChance < 0.25f && terrainNumber == 1)
        {
            gameObject.transform.position = transform.position + new Vector3(0, 0, 10);
        }
        else if (critChance < 0.125f && terrainNumber == 2)
        {
            gameObject.transform.position = transform.position + new Vector3(0, 0, 10);
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
            
        }
    }
}
