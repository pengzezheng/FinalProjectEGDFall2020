using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    // Start is called before the first frame update
    float dayTime = 0;
    float speed;
    float height;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        height = 10;
        width = 12;
    }

    // Update is called once per frame
    void Update()
    {
        dayTime += Time.deltaTime * speed;
        float x = Mathf.Cos(dayTime) * width;
        float y = Mathf.Sin(dayTime) * height;
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }
}
