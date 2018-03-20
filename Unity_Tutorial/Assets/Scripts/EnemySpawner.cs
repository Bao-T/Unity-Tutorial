using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randEnemy;
	// Use this for initialization
	void Start () {
        StartCoroutine(waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait); // spawn enemies with given min and max wait values
	}
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait); // wait before spawning multple at a time
        while (!stop)
        {
            //spawn enemies above player with random x,z coordinates within a specified range
            randEnemy = Random.Range(0, enemies.Length);
            float x = Random.Range(-spawnValues.x, spawnValues.x);
            float z = Random.Range(-spawnValues.z, spawnValues.z);

            Vector3 spawnPosition = new Vector3(x, spawnValues.y, z);
            //spawn clones of the enemy
            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
