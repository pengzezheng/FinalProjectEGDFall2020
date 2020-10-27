using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingManager : MonoBehaviour
{
    public GameObject[] buildings;
    private buildingPlacement buildingPlacements;
    // Start is called before the first frame update
    void Start()
    {
        buildingPlacements = GetComponent<buildingPlacement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    void OnGUI()
    {
        for (int i=0; i<buildings.Length; i++)
        {
            if (GUI.Button(new Rect(Screen.width/20, Screen.height/15 + Screen.height/12 * i, 120, 30), buildings[i].name))
            {
                buildingPlacements.SetItem(buildings[i]);
            }
        }
    }
}
