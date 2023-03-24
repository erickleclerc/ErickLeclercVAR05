using UnityEngine;

public class DirectToStageThree : MonoBehaviour
{
    public GameObject continueText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            continueText.gameObject.SetActive(true);
        }
    }
}
