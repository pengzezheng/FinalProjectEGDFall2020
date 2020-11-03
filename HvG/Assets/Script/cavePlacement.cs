using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavePlacement : MonoBehaviour
{
    private placeableCave placeableBuildings;
    private placeableCave placeableBuildingsOld;
    private Transform currentBuilding;
    private bool hasPlaced;
    public LayerMask buildingsMask;
    public GameObject gameManagers;

    // Start is called before the first frame update
    void Start()
    {
        gameManagers = GameObject.Find("GameManager");
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
                    if (gameManagers.GetComponent<GameManager>().GWood >= 5)
                    {
                        hasPlaced = true;
                        SoundManager soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
                        soundManager.PlaySound("build", false);
                        gameManagers.GetComponent<GameManager>().GWood -= 5;
                    }
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
                    if (placeableBuildingsOld != null)
                    {
                        placeableBuildingsOld.SetSelected(false);

                    }
                    hit.collider.gameObject.GetComponent<placeableCave>().SetSelected(true);
                    placeableBuildingsOld = hit.collider.gameObject.GetComponent<placeableCave>();
                    //Text t = GameObject.Find("messageText").GetComponent<Text>().text.ToString();
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
        if (placeableBuildings.colliders.Count > 0)
        {
            return false;
        }
        return true;
    }

    public void SetItem(GameObject b)
    {
        hasPlaced = false;
        currentBuilding = ((GameObject)Instantiate(b)).transform;
        placeableBuildings = currentBuilding.GetComponent<placeableCave>();
    }
}
