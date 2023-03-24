using UnityEngine;
using TMPro;

public class LerpText : MonoBehaviour
{
    public TMP_Text nextStageText;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        nextStageText.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        nextStageText.color = Color.Lerp(Color.black, Color.red, Mathf.PingPong(Time.time, speed));
    }
}
