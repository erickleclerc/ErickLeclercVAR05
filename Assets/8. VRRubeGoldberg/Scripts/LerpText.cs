using UnityEngine;
using TMPro;

public class LerpText : MonoBehaviour
{
    public TMP_Text nextStageText;
    public float speed = 3;

    void Start()
    {
        nextStageText.color = Color.white;
    }

    void Update()
    {
        nextStageText.color = Color.Lerp(Color.black, Color.red, Mathf.PingPong(Time.time, speed));
    }
}
