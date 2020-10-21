using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitAI : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public GameObject target;
    public bool human;
    GameObject HumanControl;
    GameObject GoblinControl;
    public enum State
    {
        waiting,
        moving,
        mining,
        building,
        following
    }
    public State state = State.waiting;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HumanControl = GameObject.Find("HumanCtrl");
        GoblinControl = GameObject.Find("GoblinCtrl");
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (State.waiting):
                GetComponent<moveToPoint>().stopped = true;
                break;
            case (State.moving):
                break;
            case (State.mining):
                if (GetComponent<moveToPoint>().stopped)
                {
                    StartCoroutine(Mine());
                }
                break;
            case (State.following):
                break;

        }
    }
    public void MoveTo(Vector3 position)
    {

    }
    IEnumerator Mine()
    {
        yield return new WaitForSeconds(2);
        if (target)
        {
            if (human) target.GetComponent<resource>().GatherResource(1, true);
            else target.GetComponent<resource>().GatherResource(1,false); 
            
        }
        else
        {
            state = State.waiting;
        }
        
    }
}
