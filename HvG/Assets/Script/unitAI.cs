using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitAI : MonoBehaviour
{
    // Unit behavior script
    Rigidbody rb;
    public GameObject target;
    public bool human;
    GameObject HumanControl;
    GameObject GoblinControl;
    public GameObject building;
    GameObject gameManager;
    GameObject soundManager;

    //List of movement states
    public enum State
    {
        waiting,
        moving,
        mining,
        building,
        following,
        wandering
    }
    public State state = State.waiting;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HumanControl = GameObject.Find("HumanCtrl");
        GoblinControl = GameObject.Find("GoblinCtrl");
        gameManager = GameObject.Find("GameManager");
        soundManager = GameObject.Find("SoundManager");
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
                if (GetComponent<moveToPoint>().stopped == false)
                {
                    soundManager.GetComponent<SoundManager>().PlaySound("footstep2", gameObject.transform.position, false);
                }
                
                break;
            case (State.mining):
                if (GetComponent<moveToPoint>().stopped)
                {
                    soundManager.GetComponent<SoundManager>().PlaySound("mine", gameObject.transform.position, false);
                    StartCoroutine(Mine());
                }
                break;
            case (State.building):
                if (GetComponent<moveToPoint>().stopped)
                {
                    soundManager.GetComponent<SoundManager>().PlaySound("build", gameObject.transform.position, false);
                    if (gameManager.GetComponent<GameManager>().getWood(human) > 0)
                    {
                        gameManager.GetComponent<GameManager>().addWood(-1, human);
                        Instantiate(building, new Vector3(transform.position.x +2f, 0.5f, transform.position.z),Quaternion.identity);


                    }
                    state = State.waiting;
                }
                break;
            case (State.following):
                GetComponent<moveToPoint>().stoppingDist = 1f;
                GetComponent<moveToPoint>().SetMovePosition(target.transform.position);
                if (GetComponent<moveToPoint>().stopped == false)
                {
                    soundManager.GetComponent<SoundManager>().PlaySound("footstep2", gameObject.transform.position, false);
                }
                break;
        }
    }
    //Wait for 2 seconds before mining resource
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
