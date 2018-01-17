using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutrientProperties : MonoBehaviour {

    public float speed;
    public float range;
    public Vector3 position;

    NutrientBehavior nBehave;

    // Use this for initialization
    void Start () {
        nBehave = GetComponent<NutrientBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
