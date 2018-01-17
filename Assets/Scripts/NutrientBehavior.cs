using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutrientBehavior : MonoBehaviour {

    NutrientProperties nProp;
    Vector3 nPosition;
    float nRange;
    float nSpeed;

    private bool moving;
    private Vector3 mTarget;


    // Use this for initialization
    void Start () {
        nProp = GetComponent<NutrientProperties>();
        nPosition = transform.position;
        nRange = nProp.range;
        nSpeed = nProp.speed;
        moving = false;
        mTarget = new Vector3(0, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {

        Movement();


        GameObject[] organisms = GameObject.FindGameObjectsWithTag("Organism");
        foreach (GameObject organism in organisms)
        {
            float eDist = Vector3.Distance(transform.position, organism.transform.position);
            if (eDist < 0.25)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Movement()
    {
        Idle();
    }

    void Idle()
    {
        if (moving == false)
        {
            mTarget = NewPosition();
            moving = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, mTarget, Time.deltaTime * nSpeed);

        float dist = Vector3.Distance(mTarget, transform.position);
        if (dist == 0f)
        {
            moving = false;
        }
    }

    Vector3 NewPosition()
    {
        Vector3 Target = Range() + nPosition;
        return Target;
    }

    Vector3 Range()
    {
        Vector3 Range = new Vector3(Random.Range(-nRange, nRange), Random.Range(-nRange, nRange), Random.Range(-nRange, nRange));
        return Range;
    }
}
