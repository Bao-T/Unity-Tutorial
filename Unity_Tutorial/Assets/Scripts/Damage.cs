using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to be put onto spell objects
public class Damage : MonoBehaviour {
    public float DamageAmount = 20f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    //when colliding with enemy
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Zombie_Health>().decreasehealth(DamageAmount);
        //send message to enemy to deduct points
        collision.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        //destroy when collision.
        Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.GetComponent<ParticleSystem>().Stop();
    }

}
