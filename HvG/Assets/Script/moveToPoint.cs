using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToPoint : MonoBehaviour
{
    Vector3 movePosition;
    [SerializeField] float distance;
    // Start is called before the first frame update
    private void Awake()
    {
        movePosition = transform.position;
    }
    public void SetMovePosition(Vector3 position)
    {
        movePosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (movePosition - transform.position).normalized;
        distance = moveDir.magnitude;
        if (distance > 0.2f) GetComponent<moveVelocity>().SetVelocity(moveDir);

    }
}
