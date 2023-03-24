using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("VRRig");
        GameObject marble = GameObject.FindGameObjectWithTag("Marble");

        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
            Destroy(marble);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
