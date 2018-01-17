using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismProperties : MonoBehaviour {

    public float health;
    public float hunger;
    public float speed;
    public float gestation;
    public float regen;
    public float sight;
    public Vector3 position;

    OrganismBehavior oBehav;

    // Use this for initialization
    void Start () {
        oBehav = GetComponent<OrganismBehavior>();
        position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
