using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Spell : MonoBehaviour
{

    public GameObject Spell_Emitter;
    public float spellchargetime = 3;
    public float spelltime = 0;
    public float downtime = 0;
    public GameObject[] Spell;
    float delay = 0.0f;
    public float cooldown = 1;
    public float Spell_Forward_Force;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   //keeps track of changing time precast for left
        if (Input.GetMouseButtonDown(0))
        {
            downtime = Time.time;
        }
        //checks to see if finished precast 
        if (Input.GetMouseButton(0))
        {
            if (delay >0)
            {
                delay -= Time.deltaTime;
            }
           else if (Time.time - downtime >= spellchargetime)
            {
                //creates clones of a spell in front of player
                GameObject Temporary_Spell_Handler;
                Temporary_Spell_Handler = Instantiate(Spell[0], Spell_Emitter.transform.position + new Vector3(0.0f, 0.0f, 0.0f), Spell_Emitter.transform.rotation) as GameObject;
                //rotate so both spell and player facing the same direction
                Temporary_Spell_Handler.transform.Rotate(Vector3.forward);

                //add physics
                Rigidbody Temporary_Rigidbody;
                Temporary_Rigidbody = Temporary_Spell_Handler.GetComponent<Rigidbody>();
                //add force to propell spell
                Temporary_Rigidbody.AddForce(transform.forward * Spell_Forward_Force);
                //destroy once out of range
                Destroy(Temporary_Spell_Handler, 5.0f);
                //delay between casting multiple clones
                delay = cooldown;
            }

        }
        //same as left mouse down
        if (Input.GetMouseButtonDown(1))
        {
            downtime = Time.time;
        }
        if (Input.GetMouseButton(1))
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
            }
            else if (Time.time - downtime >= spellchargetime)
            {
                GameObject Temporary_Spell_Handler;
                //will spawn with random x,y corrdinates in front of player
                Temporary_Spell_Handler = Instantiate(Spell[1], Spell_Emitter.transform.position + new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), 0.0f), Spell_Emitter.transform.rotation) as GameObject;
                Temporary_Spell_Handler.transform.Rotate(Vector3.forward);

                Rigidbody Temporary_Rigidbody;
                Temporary_Rigidbody = Temporary_Spell_Handler.GetComponent<Rigidbody>();
                //faster velocity
                Temporary_Rigidbody.AddForce(transform.forward * Spell_Forward_Force*3);

                Destroy(Temporary_Spell_Handler, 5.0f);
                //faster cooldown
                delay = cooldown/15;
            }

        }

    }
}
