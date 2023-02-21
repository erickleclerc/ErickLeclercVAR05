using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBehaviour : MonoBehaviour
{
    public int x, z;

   public void SetPosition (int newX, int newZ )
    {
        x = newX;
        z = newZ;
    }
}
