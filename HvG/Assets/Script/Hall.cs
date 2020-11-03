using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hall : MonoBehaviour
{
    public Button button;
    public GameObject human;
    public GameObject gameManagers;
    // Start is called before the first frame update
    void Start()
    {
        gameManagers = GameObject.Find("GameManager");
        button.onClick.AddListener(Producing);
        button.transform.position = new Vector3(Screen.width*4/5,Screen.height/5);
        button.gameObject.SetActive(false);
        // button.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Producing()
    {
        if (gameManagers.GetComponent<GameManager>().HMeat >= 5)
        {
            Instantiate(human, new Vector3(gameObject.transform.position.x - 2, 1.03f, gameObject.transform.position.z), Quaternion.identity);
            gameManagers.GetComponent<GameManager>().HMeat -= 5;
        }
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
