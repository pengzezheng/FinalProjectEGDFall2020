using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Move the player with the WASD keys
    void Update()
    {
        float x = 0f;
        float y = 0f;
        
        if (Input.GetKey(KeyCode.W)) y = 1f;
        if (Input.GetKey(KeyCode.A)) x = -1f;
        if (Input.GetKey(KeyCode.S)) y = -1f;
        if (Input.GetKey(KeyCode.D)) x = 1f;

        Vector3 moveVector = new Vector3(x, y).normalized;
        GetComponent<moveVelocity>().SetVelocity(moveVector);
    }
}
