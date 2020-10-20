using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon : MonoBehaviour
{
    GameObject dragoon;
    double timer = 20;
    // Start is called before the first frame update
    void Start()
    {
        dragoon = GameObject.Find("Dragon");
        dragoon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 15 && timer > 5)
        {
            dragoon.SetActive(true);
        }else
        {
            dragoon.SetActive(false);
        }
    }
}
