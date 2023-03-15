using UnityEngine;
using System.Collections;

public class PinBehaviour : MonoBehaviour
{
    public Bolf bolfScript;
    private bool hitAlready = false;
    private float angularDifference;

    void Update()
    {
        angularDifference = Vector3.Angle(Vector3.up, transform.up);     //ANGLE the gameobject is from pointing straight up

        if (hitAlready == false && angularDifference > 18)
        {
            bolfScript.score++;
            hitAlready = true;
            StartCoroutine(RemovePin());
        }
    }

    IEnumerator RemovePin()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
        StopCoroutine(RemovePin());
    }
}
