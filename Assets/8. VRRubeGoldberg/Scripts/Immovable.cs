using UnityEngine;

public class Immovable : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        BoxCollider box = GetComponent<BoxCollider>();
        box.isTrigger = true;
    }
}
