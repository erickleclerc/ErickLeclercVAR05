using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CourseOne()
    {
        SceneManager.LoadScene("Bolf Scene 1");
    }

    public void CourseTwo()
    {
        SceneManager.LoadScene("Bolf Scene 1"); // CHANGE TO SCENE 2 ONCE ITS MADE
    }
}
