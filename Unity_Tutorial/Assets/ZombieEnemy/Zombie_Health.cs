using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Health : MonoBehaviour {

    public float max_health = 100f;
    public float cur_health = 0f;
    public GameObject health_bar;

	// Use this for initialization
	void Start () {
        cur_health = max_health;
	}
	
	// Update is called once per frame
	void Update () {
        if (cur_health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void decreasehealth(float DamageAmount)
    {
        cur_health -= DamageAmount;
        float calc_health = cur_health / max_health;
        setHealthBar(calc_health);
    }

    public void setHealthBar(float myHealth)
    {
        health_bar.transform.localScale = new Vector3(myHealth, health_bar.transform.localScale.y, health_bar.transform.localScale.z);
    }
}
