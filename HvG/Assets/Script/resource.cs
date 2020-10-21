using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class resource : MonoBehaviour
{
    GameObject gameManager;
    public enum Type
    {
        Wood
    }
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    // Start is called before the first frame update
    public Type type;
    public int quantity;

    public void GatherResource(int amount,bool human)
    {
        quantity -= 1;
        gameManager.GetComponent<GameManager>().addWood(human);
        if (quantity < 1) { Destroy(gameObject); }
    }
}
