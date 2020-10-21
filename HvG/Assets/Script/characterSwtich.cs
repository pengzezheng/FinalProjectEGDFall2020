using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSwtich : MonoBehaviour
{
    GameObject HumanControl;
    GameObject GoblinControl;
    // Start is called before the first frame update
    void Start()
    {
        HumanControl = GameObject.Find("HumanCtrl");
        GoblinControl = GameObject.Find("GoblinCtrl");
        HumanControl.SetActive(false);
        GoblinControl.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            HumanControl.SetActive(false);
            GoblinControl.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            HumanControl.SetActive(true);
            GoblinControl.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            HumanControl.SetActive(false);
            GoblinControl.SetActive(true);
        }
    }
}
