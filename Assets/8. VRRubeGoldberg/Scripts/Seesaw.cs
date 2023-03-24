using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    public GameObject fireworkOne;
    public GameObject fireworkTwo;

  

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

         fireworkOne.gameObject.SetActive(true);
        fireworkTwo.gameObject.SetActive(true);
        Destroy(gameObject);

        
    }
}
