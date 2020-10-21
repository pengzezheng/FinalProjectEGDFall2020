using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    GameObject CamMain;
    GameObject CamH;
    GameObject CamG;
    GameObject HumanControl;
    GameObject GoblinControl;
    // Start is called before the first frame update
    void Start()
    {
        CamMain = GameObject.Find("CameraMain");
        CamH = GameObject.Find("CameraH");
        CamG = GameObject.Find("CameraG");
        HumanControl = GameObject.Find("HumanCtrl");
        GoblinControl = GameObject.Find("GoblinCtrl");
        CamMain.SetActive(true);
        CamH.SetActive(false);
        CamG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            CamMain.SetActive(true);
            CamH.SetActive(false);
            CamG.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            CamMain.SetActive(false);
            CamH.SetActive(true);
            CamG.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            CamMain.SetActive(false);
            CamH.SetActive(false);
            CamG.SetActive(true);
        }
    }
}
