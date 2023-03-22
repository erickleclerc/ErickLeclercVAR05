using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeTransparency : MonoBehaviour
{
    public LayerMask rubeMask;
    public float transparencyAmount = 0.5f;
    public float resetAmount = 1f;

    private bool isAlreadyTransparent = false;
    private VRInputActions inputActions;

    private void Awake()
    {
        inputActions = new VRInputActions();
        inputActions.Enable();
    }


    void Update()
    {
        //Done with Oculus Controller or KEYBOARD
        if (inputActions.Default.BButtonRightHand.WasPressedThisFrame() || Keyboard.current.nKey.wasPressedThisFrame)
        {
            if (isAlreadyTransparent == false)
            {
                ChangeOpacity(transparencyAmount);
                isAlreadyTransparent = true;
            }
            else if (isAlreadyTransparent == true)
            {
                ChangeOpacity(resetAmount);
                isAlreadyTransparent = false;
            }
        }
    }

    private void ChangeOpacity(float transparencyValue)
    {
        Renderer[] renderers = FindObjectsOfType<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            if (((1 << renderer.gameObject.layer) & rubeMask) != 0)
            {
                Material[] materials = renderer.materials;

                for (int i = 0; i < materials.Length; i++)
                {
                    Color color = materials[i].color;
                    color.a = transparencyValue;
                    materials[i].color = color;
                }
            }
        }
    }
}



