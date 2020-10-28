using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Move the player with WASD, arrows, or control stick if we use it
    public Camera cam;
    public SoundManager soundManager;
    [SerializeField]float speed;
    Vector2 input;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Use axes for movement 
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (input.magnitude > 0f) soundManager.PlaySound("footstep",gameObject.transform.position, false);
        
        Vector3 camF =  cam.transform.forward;
        Vector3 camR = cam.transform.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
        //Translate in direction of camera
        rb.transform.position += (camF * input.y + camR * input.x)*Time.deltaTime * speed;
    }
}
