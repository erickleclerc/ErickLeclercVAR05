using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ResetMachine : MonoBehaviour
{
    private VRInputActions inputActions;

    private void Awake()
    {
        inputActions = new VRInputActions();
        inputActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputActions.Default.TriggerLeftHand.IsPressed() || Keyboard.current.rKey.isPressed)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);



        }

    }
}
