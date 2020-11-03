﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeableCave : MonoBehaviour
{
    public List<Collider> colliders = new List<Collider>();
    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void OnGUI()
    {
        if (isSelected)
        {
            if (gameObject.name == "House")
            {
                GUI.Button(new Rect(100, 200, 100, 30), "check");
            }
            else
            {
                GUI.Button(new Rect(100, 200, 100, 30), "ooo");
            }
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Building")
        {
            colliders.Add(other);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building")
        {
            colliders.Remove(other);
        }
    }

    public void SetSelected(bool s)
    {
        isSelected = s;
    }
}