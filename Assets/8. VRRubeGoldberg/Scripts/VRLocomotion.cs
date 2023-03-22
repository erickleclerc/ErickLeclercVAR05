using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    private VRInputController inputController;

    public Transform headFacing;
    public float moveSpeed = 2f;


    private void Awake()
    {
        inputController = GetComponent<VRInputController>();
    }


    void Update()
    {
        Vector2 moveInput = inputController.Joystick;

        //Even if head tilts, it'll correct to true forward and side-to-side
        Vector3 forward = headFacing.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 sideToSide =  headFacing.right;     //-right = left
        sideToSide.y = 0;
        sideToSide = sideToSide.normalized;

        // Convert moveDirection from *local* space to *world* space
        Vector3 moveDirection = forward * moveInput.y + sideToSide * moveInput.x;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
