using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cave : MonoBehaviour
{
    public Button button;
    public GameObject goblin;
    public GameObject gameManagers;
    // Start is called before the first frame update
    void Start()
    {
        gameManagers = GameObject.Find("GameManager");
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
        if (gameManagers.GetComponent<GameManager>().GMeat >= 5)    
        {
            Instantiate(goblin, new Vector3(gameObject.transform.position.x + 2, 1.03f, gameObject.transform.position.z), Quaternion.identity);
            gameManagers.GetComponent<GameManager>().GMeat -= 5;
        }
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
