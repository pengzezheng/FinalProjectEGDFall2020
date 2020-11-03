using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmingCave : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Producing);
        button.transform.position = new Vector3(Screen.width * 4 / 5, Screen.height / 5);
        button.gameObject.SetActive(false);
        // button.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Producing()
    {

    }

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(1))
        {
            button.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            button.gameObject.SetActive(false);
        }
        if (gameObject.GetComponent<placeableCave>().isSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                button.gameObject.SetActive(true);
            }
        }
    }
}
