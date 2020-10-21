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
    Camera Cam;

    // Update is called once per frame
    void Update()
    {
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
                    if (Input.GetMouseButtonDown(0))
                    {
                        selected = hit.transform.gameObject;
                        PrintName(hit.transform.gameObject);
                        Push(rb);

                    }
                }
            }
            if (selected)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    selected.GetComponent<moveToPoint>().SetMovePosition(hit.point);
                }
            }
        }
    }

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
