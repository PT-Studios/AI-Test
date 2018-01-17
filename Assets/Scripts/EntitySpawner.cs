using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour {

    public GameObject Entity;
    public float radius;
    public float interval;

	// Use this for initialization
	void Start () {
        /*
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Entity, Random.insideUnitCircle * radius, Quaternion.identity);
        }*/
        StartCoroutine(SpawnObject());
    }
	
	// Update is called once per frame
	void Update () {
        //Entity.transform.position = Random.insideUnitCircle * radius;
    }

    public IEnumerator SpawnObject()
    {
        bool spawning = true;

        while (spawning)
        {
            yield return new WaitForSeconds(interval);
            Instantiate(Entity, Random.insideUnitCircle * radius, Quaternion.identity);
            spawning = false;
        }
    }
}
