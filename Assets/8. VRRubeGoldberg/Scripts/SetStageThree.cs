using UnityEngine;

public class SetStageThree : MonoBehaviour
{
    public GameObject stageThree;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            stageThree.gameObject.SetActive(true);
        }
    }
}
