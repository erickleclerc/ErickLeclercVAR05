using UnityEngine;

public class SnoozeClock : MonoBehaviour
{
    public AudioSource source;
    public GameObject finalText;
    public CourseTimer courseTimer;

    public bool test = false;


    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        BoxCollider box = GetComponent<BoxCollider>();
        box.isTrigger = true;
    }

    private void Update()
    {
        if (test == true)
        {
            source.enabled = false;
            courseTimer.stopTime = true;
            finalText.gameObject.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightHandOnlyGrab"))
        {
            source.enabled = false;
            courseTimer.stopTime = true;
            finalText.gameObject.SetActive(true);

        }
    }
}
