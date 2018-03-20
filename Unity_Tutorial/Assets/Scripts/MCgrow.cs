using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCgrow : MonoBehaviour {
	// Use this for initialization
	void Start () {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //animates magic circle
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            if (gameObject.transform.localScale.x <= 1f)
         gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        //stops animation
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
