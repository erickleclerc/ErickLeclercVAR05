using UnityEngine;

public class SnoozeClock : MonoBehaviour
{
    public AudioSource source;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RightHandOnlyGrab"))
        {
            source.enabled = false;

        }
    }
    
}
