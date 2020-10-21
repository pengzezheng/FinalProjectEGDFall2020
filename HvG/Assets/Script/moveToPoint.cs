using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToPoint : MonoBehaviour
{
    Vector3 movePosition;
    public bool stopped;
    [SerializeField] float distance;
    // Start is called before the first frame update
    private void Awake()
    {
        movePosition = transform.position;
    }
    public void SetMovePosition(Vector3 position)
    {
        movePosition = position;
        stopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            Vector3 moveDir = (movePosition - transform.position);
            distance = moveDir.magnitude;
            if (distance > 1f) GetComponent<moveVelocity>().SetVelocity(moveDir.normalized);
            else stopped = true;
        }
        else
        {
            GetComponent<moveVelocity>().SetVelocity(Vector3.zero);
        }
        

    }
}
