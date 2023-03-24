using UnityEngine;

public class ActivateStageThree : MonoBehaviour
{
    public GameObject coundownText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("VRRig"))
        {
            coundownText.gameObject.SetActive(true);
        }
    }
}
