using UnityEngine;

public class Seesaw : MonoBehaviour
{
    public GameObject fireworks;
    public GameObject theEndText;
    public GameObject stageFour;

    private void Update()
    {
        transform.eulerAngles += new Vector3 (20 * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);

        fireworks.gameObject.SetActive(true);
        theEndText.gameObject.SetActive(true);
        stageFour.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
