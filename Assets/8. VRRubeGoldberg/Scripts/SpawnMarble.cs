using UnityEngine;

public class SpawnMarble : MonoBehaviour
{
    public GameObject marble;
    public GameObject stageTwo;
    public GameObject rightHandText;

    private GameObject newMarble;

    private void OnCollisionEnter(Collision collision)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);

        stageTwo.gameObject.SetActive(true);

        if (newMarble == null)
        {
            newMarble = Instantiate(marble, new Vector3(-12.8f, 4f, -12f), Quaternion.identity);
            newMarble.gameObject.tag = "Marble";
            rightHandText.gameObject.SetActive(true);
        }
        else 
        {
            return;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z);
    }
}
