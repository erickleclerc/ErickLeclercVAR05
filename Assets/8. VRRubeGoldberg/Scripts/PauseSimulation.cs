using UnityEngine;
using UnityEngine.InputSystem;

public class PauseSimulation : MonoBehaviour
{
    private VRInputActions inputActions;

    private void Awake()
    {
        inputActions = new VRInputActions();
        inputActions.Enable();
    }

    private void FixedUpdate()
    {
        //Done with CONTROLLER and KEYBOARD for testing
        if (inputActions.Default.XButtonLeftHand.IsPressed() || Keyboard.current.oKey.isPressed)
        {
            Physics.autoSimulation = false;
        }
        else if (inputActions.Default.YButtonLeftHand.IsPressed() || Keyboard.current.pKey.isPressed)
        {
            Physics.autoSimulation = true;
            //Physics.Simulate(Time.fixedDeltaTime);
        }
    }
}
