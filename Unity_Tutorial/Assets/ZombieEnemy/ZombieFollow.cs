using UnityEngine;
using System.Collections;

public class ZombieFollow : MonoBehaviour
{

    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 100;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    public Vector3 goTo;

    void Update()
    {
        //locate the player
        ThePlayer = GameObject.Find("FPSController");
        
        //turn so that looking at player
        transform.LookAt(ThePlayer.transform);
        //performs a ray cast to see if player is within range
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance < AllowedRange)
            {
                //move enemy
                EnemySpeed = 3;
                //if not attacking
                if (AttackTrigger == 0)
                {
                    //keep moving towards player
                    TheEnemy.GetComponent<Animation>().Play("Walking");
                    CharacterController controller = GetComponent<CharacterController>();
                    Vector3 forward = transform.TransformDirection(Vector3.forward);
                    controller.SimpleMove(forward*EnemySpeed);
                }
            }
            else // if outside range
            {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Play("Idle");
            }
        }

        if (AttackTrigger == 1) // if attack trigger
        {
            EnemySpeed = 0;
            TheEnemy.GetComponent<Animation>().Play("Attacking");
        }
    }

    void OnTriggerEnter() // on collision set attack trigger
    {
        AttackTrigger = 1;
    }

    void OnTriggerExit() // when outside attack range disable
    {
        AttackTrigger = 0;
    }

}