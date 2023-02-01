using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    void LateUpdate()
    {
        GameObject selectedPlayer = GameObject.FindWithTag("Selected Player");
        if (selectedPlayer != null)
        {
            transform.position = selectedPlayer.transform.position + new Vector3(0,5,-1); 
        }
    }
}
