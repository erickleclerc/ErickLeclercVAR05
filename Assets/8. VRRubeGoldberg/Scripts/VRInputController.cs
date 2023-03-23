using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class VRInputController : MonoBehaviour
{
    private VRInputActions actions;

    //public variable generally have CAPITAL letters
    public Vector2 Joystick;
    public float RightTrigger;

    private void Awake()                    
    {
        actions = new VRInputActions();
        actions.Enable();
    }

    //OnValidate only called in the INSPECTOR when you modify a public field (joystick/rightTrigger values)
    private void OnValidate()
    {
        Joystick = Vector3.ClampMagnitude(Joystick, 1);  //don't let it go past 1 just in case
        RightTrigger = Mathf.Clamp01(RightTrigger);
    }

    void Update()
    {
        XRHMD hmd = InputSystem.GetDevice<XRHMD>();

        if (hmd != null)
        {
            Joystick = actions.Default.Joystick.ReadValue<Vector2>();
            RightTrigger = actions.Default.RightTrigger.ReadValue<float>();
        }
    }
}
