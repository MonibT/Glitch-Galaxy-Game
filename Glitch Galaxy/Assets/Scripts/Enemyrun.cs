using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyrun : StateMachineBehaviour
{
    public float speed = 11f;
    public float AttackRange = 17f;
    public float AwakeRange = 20f;


    Transform player;
    Rigidbody2D rb;
    Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();

        enemy = animator.GetComponent<Enemy>(); 

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (Vector2.Distance(player.position, rb.position) <= AwakeRange)
        {
            enemy.LookAtPlayer();
            
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
            else
            {
                animator.SetTrigger("GoToIdle");
            }




        if (Vector2.Distance(player.position, rb.position) <= AttackRange)
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            animator.SetTrigger("notattck");
        }
    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
     
    }

}
