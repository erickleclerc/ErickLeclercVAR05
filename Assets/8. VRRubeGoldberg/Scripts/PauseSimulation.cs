using UnityEngine;
using UnityEngine.InputSystem;

public class PauseSimulation : MonoBehaviour
{
    private VRInputActions inputActions;
    private bool isCurrentlyPaused = false;

    private void Awake()
    {
        inputActions = new VRInputActions();
        inputActions.Enable();
    }

    private void FixedUpdate()
    {
        if (isCurrentlyPaused == false)
        {
            //Done with CONTROLLER and KEYBOARD for testing
            if (inputActions.Default.XButtonLeftHand.WasPressedThisFrame() || Keyboard.current.oKey.isPressed)
            {
                Physics.autoSimulation = false;
                isCurrentlyPaused = true;
            }
        }
        else if (isCurrentlyPaused == true)
        {
            if (inputActions.Default.XButtonLeftHand.WasPressedThisFrame() || Keyboard.current.oKey.isPressed)
            {
                Physics.autoSimulation = true;
                isCurrentlyPaused = false;
            }
        }
    }
}
