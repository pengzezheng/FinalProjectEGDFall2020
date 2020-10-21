using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Move the player with the WASD keys
    public Camera cam;
    [SerializeField]float speed;
    Vector2 input;
    float heading = 0;
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 camF =  cam.transform.forward;
        Vector3 camR = cam.transform.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF * input.y + camR * input.x)*Time.deltaTime * speed;
    }
}
