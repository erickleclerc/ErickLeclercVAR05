using UnityEngine;
using TMPro;

public class NameAndAge : MonoBehaviour
{
    public TMP_InputField userName;
    public TMP_InputField age;

    public TextMeshProUGUI final;

    public void Naming()
    {
        final.text = "Hello " + userName.text + ", you are " + age.text + " years old";
    }

    void Start()
    {
        final.text = "Hello NAME, you are AGE years old";
    }
}
