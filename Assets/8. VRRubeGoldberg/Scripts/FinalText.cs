using UnityEngine;
using TMPro;

public class FinalText : MonoBehaviour
{
    public TMP_Text text;
    public CourseTimer courseTimer;

    void Start()
    {
        text.text = "Course completed in: \n" + courseTimer.finalTime.ToString() + "sec \n Reset?";
    }
}
