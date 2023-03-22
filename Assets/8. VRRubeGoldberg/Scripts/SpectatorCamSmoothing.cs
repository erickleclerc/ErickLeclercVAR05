using UnityEngine;

public class SpectatorCamSmoothing : MonoBehaviour
{
    public  Transform target;
    public float translateSpeed = 6f;
    public float rotateSpeed = 8f;

    //so that all the logic has finished before executing
    private void LateUpdate()      
    {
        Vector3 targetPosition = target.position;
        Quaternion targetRotation = target.rotation;

        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
