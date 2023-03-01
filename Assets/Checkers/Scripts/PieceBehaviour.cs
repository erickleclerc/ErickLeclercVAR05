using UnityEngine;

public class PieceBehaviour : MonoBehaviour
{
    public int x, z;

   public void SetPosition (int newX, int newZ )
    {
        x = newX;
        z = newZ;

        transform.position = new Vector3(x, 0, z);
    }
}
