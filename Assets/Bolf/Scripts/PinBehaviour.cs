using UnityEngine;
using System.Collections;


public class PinBehaviour : MonoBehaviour
{
    public Bolf bolfScript;
    private bool hitAlready = false;
    private float rotationalDifference;

    void Update()
    {
        rotationalDifference = Vector3.Angle(Vector3.up, transform.up);     //ANGLE the gameobject is from pointing straight up

        if (hitAlready == false && rotationalDifference > 18)
        {
            //Debug.Log("HIT");
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
