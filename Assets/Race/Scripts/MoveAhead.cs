using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAhead : MonoBehaviour
{
    private int critChance;

    public void MoveForward()
    {
        if (critChance == 2)
        {
            gameObject.transform.position = transform.position + new Vector3(0, 0, 10);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Muddy")
        {
            critChance = Random.Range(1, 9);
            Debug.Log($"crit chance is {critChance}");
        }
        else if (other.gameObject.tag == "Regular")
        {
            critChance = Random.Range(1, 4);
            Debug.Log($"crit chance is {critChance}");
        }
    }
}
