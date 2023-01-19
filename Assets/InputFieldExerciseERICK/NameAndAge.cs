using System.Collections;
using System.Collections.Generic;
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

   
    // Start is called before the first frame update
    void Start()
    {
        final.text = "Hello NAME, you are AGE years old";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
