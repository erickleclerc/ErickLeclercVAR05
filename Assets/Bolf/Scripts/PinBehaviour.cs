
using UnityEngine;


public class PinBehaviour : MonoBehaviour
{
    Bolf bolfScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HasBeenHit()
    {
        if (gameObject.transform.eulerAngles.x != 0)
        {
            Debug.Log("HIT");
            bolfScript.score++;
        }

    }
}
