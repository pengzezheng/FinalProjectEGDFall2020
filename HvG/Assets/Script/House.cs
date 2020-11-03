using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    // private placeableBuilding placeableBuildings;
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            button.gameObject.SetActive(false);
        }
        if (gameObject.GetComponent<placeableBuilding>().isSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                button.gameObject.SetActive(true);
            }
        }
    }
}
