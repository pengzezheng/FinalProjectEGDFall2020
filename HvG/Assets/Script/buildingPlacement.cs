using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildingPlacement : MonoBehaviour
{
    private placeableBuilding placeableBuildings;
    private placeableBuilding placeableBuildingsOld;
    private Transform currentBuilding;
    private bool hasPlaced; 
    public LayerMask buildingsMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x, m.y, transform.position.y);
        Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(m);

        if (currentBuilding != null && !hasPlaced)
        {
            currentBuilding.position = new Vector3(p.x, 0, p.z);

            if (Input.GetMouseButtonDown(0))
            {
                if (IsLegalPosition())
                {
                    hasPlaced = true;
                    SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
                    soundManager.PlaySound("build", false);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = new RaycastHit();
                Ray ray = new Ray(new Vector3(p.x, 8, p.z), Vector3.down);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, buildingsMask))
                {
                    if(placeableBuildingsOld != null)
                    {
                        placeableBuildingsOld.SetSelected(false);

                    }
                    hit.collider.gameObject.GetComponent<placeableBuilding>().SetSelected(true);
                    placeableBuildingsOld = hit.collider.gameObject.GetComponent<placeableBuilding>();
                    Text t = GameObject.Find("messageText").GetComponent<Text>().text.ToString();
                }
                else
                {
                    if (placeableBuildingsOld != null)
                    {
                        placeableBuildingsOld.SetSelected(false);
                        
                    }
                }
            }
        }
    }


    bool IsLegalPosition()
    {
        if(placeableBuildings.colliders.Count > 0)
        {
            return false;
        }
        return true;
    }

    public void SetItem(GameObject b)
    {
        hasPlaced = false;
        currentBuilding = ((GameObject)Instantiate(b)).transform;
        placeableBuildings = currentBuilding.GetComponent<placeableBuilding>();
    }
}
