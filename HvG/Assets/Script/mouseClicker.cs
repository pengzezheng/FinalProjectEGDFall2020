using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseClicker : MonoBehaviour
{
    public float force = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject selected;
    public GameObject target;
    Camera Cam;

    // Update is called once per frame
    void Update()
    {
        //Set Cam before checking raycast
        if (!Cam) Cam = GetCamera();
        RaycastHit hit;
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform)
            {
                Rigidbody rb;
                
                if (rb = hit.transform.GetComponent<Rigidbody>())
                {
                    //Set selected unit when clicking on them, set to waiting if an ai
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hit.transform.gameObject.tag == "Human" || hit.transform.gameObject.tag == "Goblin")
                        {
                            selected = hit.transform.gameObject;
                            selected.GetComponent<unitAI>().state = unitAI.State.waiting;
                        }
                        
                        PrintName(hit.transform.gameObject);
                        Push(rb);
                    }
                }
            }
            if (selected)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //Move to an mine resource
                    if (hit.transform.gameObject.tag == "Resource")
                    {
                        target = hit.transform.gameObject;
                        selected.GetComponent<unitAI>().state = unitAI.State.mining;
                        selected.GetComponent<unitAI>().target = hit.transform.gameObject;
                        selected.GetComponent<moveToPoint>().SetMovePosition(hit.point);
                        
                    }
                    //Start following the player
                    if (hit.transform.gameObject.tag == "Player")
                    {
                        target = hit.transform.gameObject;
                        selected.GetComponent<unitAI>().target = hit.transform.gameObject;
                        selected.GetComponent<unitAI>().state = unitAI.State.following;

                    }
                }
                //Move to a position when right clicking
                if (Input.GetMouseButtonDown(1))
                {
                    selected.GetComponent<unitAI>().state = unitAI.State.moving;
                    selected.GetComponent<moveToPoint>().SetMovePosition(hit.point);
                }
                //Build a prefab at the location the mouse is when pressing B
                if (Input.GetKeyDown(KeyCode.B))
                {
                    selected.GetComponent<unitAI>().state = unitAI.State.building;
                    selected.GetComponent<moveToPoint>().SetMovePosition(hit.point);
                }
            }
        }
    }
    //Set Cam to the current camera
    private Camera GetCamera()
    {
        GameObject CamMain = GameObject.Find("CameraMain");
        GameObject CamH = GameObject.Find("CameraH");
        GameObject CamG = GameObject.Find("CameraG");
        if (CamMain) return CamMain.GetComponent<Camera>();
        if (CamH) return CamH.GetComponent<Camera>();
        if (CamG) return CamG.GetComponent<Camera>();
        return CamMain.GetComponent<Camera>();
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

    private void Push(Rigidbody rig)
    {
        rig.AddForce(rig.transform.up * force, ForceMode.Impulse);
    }
}
