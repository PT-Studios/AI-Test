using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismBehavior : MonoBehaviour {

    OrganismProperties oProp;
    Vector3 oPosition;
    float speed;
    float sight;

    private bool moving;
    private bool scanned;
    private Vector3 mTarget;
    private GameObject eObject;

    // Use this for initialization
    void Start () {
        oProp = GetComponent<OrganismProperties>();
        oPosition = oProp.position;
        speed = oProp.speed;
        sight = oProp.sight;

        moving = false;
        scanned = false;
        mTarget = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {

        Scan();
        if (scanned == true)
            ScannedMove();
        else
            Idle();

    }

    void Scan()
    {

        if (scanned == false)
        {
            GameObject[] nutrients = GameObject.FindGameObjectsWithTag("Nutrient");
            foreach (GameObject nutrient in nutrients)
            {
                float eDist = Vector3.Distance(transform.position, nutrient.transform.position);
                //Debug.Log("dist: " + eDist);
                if (eDist < sight)
                {
                    scanned = true;
                    eObject = nutrient;
                    //Debug.Log("targ: " + eTarget);
                }
            }
        }
    }

    void ScannedMove()
    {
        if (eObject)
        {
            transform.position = Vector3.MoveTowards(transform.position, eObject.transform.position, Time.deltaTime * speed);
            float dist = Vector3.Distance(eObject.transform.position, transform.position);
            Debug.Log("ibj: " + eObject);
        } else
        {
            scanned = false;
        }
    }

    void Idle()
    {
        if (moving == false)
        {
            mTarget = NewPosition();
            moving = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, mTarget, Time.deltaTime * speed);

        float dist = Vector3.Distance(mTarget, transform.position);
        //Debug.Log("Distance to target: " + dist);
        if (dist == 0f)
        {
            moving = false;
        }
    }

    Vector3 NewPosition()
    {
        Vector3 Target = Range() + oPosition;
        //Debug.Log("Move Position: " + Target);
        return Target;
    }

    Vector3 Range()
    {
        Vector3 Range = new Vector3(Random.Range(-sight, sight), Random.Range(-sight, sight), Random.Range(-sight, sight));
        return Range;
    }
}
