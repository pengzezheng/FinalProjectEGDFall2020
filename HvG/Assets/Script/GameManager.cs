using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] int HWood;
    [SerializeField] int GWood;
    private Text HWoodCount;
    private Text GWoodCount;
    // Start is called before the first frame update
    void Start()
    {
        HWoodCount = GameObject.Find("HWoodCount").GetComponent<Text>();
        GWoodCount = GameObject.Find("GWoodCount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HWoodCount.text = HWood.ToString();
        GWoodCount.text = GWood.ToString();
    }
    public void addWood(bool human)
    {
        if (human) HWood += 1;
        else { GWood += 1; }
    }
}
