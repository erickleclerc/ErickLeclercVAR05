using UnityEngine;

public class CourseTimer : MonoBehaviour
{
    private float stopwatch = 0;
    public int finalTime;
    public bool stopTime = false;

    void Update()
    {
        if (stopTime == false)
        {
            stopwatch += Time.deltaTime;
            finalTime = (int)stopwatch;
        }
        else if (stopTime == true)
            {
            finalTime = (int)stopwatch;
        }
    }
}
