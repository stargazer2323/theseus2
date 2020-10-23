using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class MinotaurMovement : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public GameObject minotaur;
    public Vector3 minotaurPosition;
    public CharacterMove move = new CharacterMove();

    bool minotaurMoving = false;
    // Update is called once per frame
    private void Start()
    {

        minotaurPosition = minotaur.transform.position;
       
    }


    private void Update()
    {

        if (minotaurMoving) 
        {
            int moveSq= move.stepsNum*10;
            print(moveSq);
                if (Math.Abs( minotaurPosition.x - minotaur.transform.position.x )> moveSq||Math.Abs( minotaurPosition.z-minotaur.transform.position.z)>moveSq)
                {
                    print(minotaur.transform.position);
                    minotaur.GetComponent<NavMeshAgent>().isStopped = true;
                    minotaurMoving = false;

                    print("minotaur last  position" + minotaurPosition.z);
                    

                }            
        }
    }


    public void MinotaurM()
    {
        
        minotaurMoving = true;
        minotaur.GetComponent<NavMeshAgent>().isStopped = false;
        Vector3 positionOfPlayer = GameObject.Find("Player").transform.position;

        
       
          //print("minotaur first position position"+minotaurPosition);

         

            agent.SetDestination(positionOfPlayer);
        if (move.cannotGoThere == true)
        {
            minotaur.GetComponent<NavMeshAgent>().isStopped = true;
            move.cannotGoThere = false;
        }

            minotaurPosition = minotaur.transform.position;
       
    }
    public void nearPlayer()
    {
        if (agent.remainingDistance < 5)
        {
            string nearYou = "You can feel hes breath";
            print(nearYou);
        }


    }

}
