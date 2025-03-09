using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject[] objectsToSpawn;
    public GameObject bomb;
    public Transform[] spawnPlaces;
    public float minWait = .4f;
    public float maxWait = 1.2f;
    public float minForce = 15.0f;
    public float maxForce = 23.0f;
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject go = null;
            float p = Random.Range(0, 100);
            if(p < 20)
            {
                go = bomb;
            }
            else
            {
                go = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            }

            GameObject fruit = Instantiate(go, t.position, t.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            Debug.Log("Fruits gets spawned");

            Destroy(fruit, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
