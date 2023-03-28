using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immovable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        BoxCollider box = GetComponent<BoxCollider>();
        box.isTrigger = true;
    }
}
