using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAhead : MonoBehaviour
{
    private int critChance;

    public void MoveForward()
    {
        //if (critChance == 2)
        //{
            gameObject.transform.position = transform.position + new Vector3(0, 0, 5);
       // }
       // else
        //{
         //   gameObject.transform.position = transform.position;
       // }

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Muddy"))
        {
            critChance = Random.Range(1, 9);
            Debug.Log($"crit chance is {critChance}");
        }

        if (other.gameObject.CompareTag("Regular"))
        {
            critChance = Random.Range(1, 4);
            Debug.Log($"crit chance is {critChance}");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Muddy"))
        {
            critChance = Random.Range(1, 9);
            Debug.Log($"crit chance is {critChance}");
        }

        if (other.gameObject.CompareTag("Regular"))
        {
            critChance = Random.Range(1, 4);
            Debug.Log($"crit chance is {critChance}");
        }
    }
}
