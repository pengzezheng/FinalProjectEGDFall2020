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

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform)
            {
                Rigidbody rb;

                if (rb = hit.transform.GetComponent<Rigidbody>())
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        PrintName(hit.transform.gameObject);
                        Push(rb);
                    }
                }
            }
        }
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
