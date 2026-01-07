using System;
using UnityEngine;

public class DebugComponent : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("HELLO!");
        }
    }
    
    
}
